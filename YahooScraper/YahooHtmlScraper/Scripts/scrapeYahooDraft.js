(function (console) {

    console.save = function (data, filename) {

        if (!data) {
            console.error('Console.save: No data');
            return;
        }

        if (!filename)
            filename = 'console.json';

        if (typeof data === "object") {
            data = JSON.stringify(data, undefined, 4);
        }

        let blob = new Blob([data], { type: 'text/json' }),
            e = document.createEvent('MouseEvents'),
            a = document.createElement('a');

        a.download = filename;
        a.href = window.URL.createObjectURL(blob);
        a.dataset.downloadurl = ['text/json', a.download, a.href].join(':');
        e.initMouseEvent('click', true, false, window, 0, 0, 0, 0, 0, false, false, false, false, 0, null);
        a.dispatchEvent(e);
    };
})(console);

function scrapDraft() {
    let leagueTitleMatch = document.querySelector("#league-info").firstElementChild.querySelector(".Ta-end").innerText.match("(.*) \\(ID# (\\d+)\\)");
    let leagueName = leagueTitleMatch[1];
    let yId = leagueTitleMatch[2];
    let seasonYearMatch = document.querySelector("#league-info").firstElementChild.innerText.match(/(20\d\d).*? Season/);
    let seasonYear = seasonYearMatch ? seasonYearMatch[1] : new Date().getFullYear();
    let isAuction = document.querySelector("td.cost") !== null;

    let leagueDraft = {
        LeagueName: leagueName,
        YahooLeagueId : yId,
        SeasonYear: seasonYear,
        Teams: [],
        IsAuction: isAuction
    };

    let drafts = Array.from(document.querySelectorAll("#drafttables.team table.Table"));
    for (const draft of drafts) {
        let teamName = draft.querySelector("thead th").innerText;
        let teamDraft = {
            TeamName: teamName,
            Players: []
        };

        let players = draft.querySelectorAll("tbody tr:not(.table-footer)");
        for (const player of players) {
            let round = parseInt(player.children[0].innerText.match(/(\d+)/)[0]);
            let draftPos = parseInt(player.children[1].innerText.match(/(\d+)/)[0]);
            let fullName, playerTeam, playerPosition;
            if (!seasonYearMatch) //archived seasons doesn't display the players position and team in parens e.g. Lamar Jackson (Bal - QB)
            {
                let playerMatch = player.children[2].innerText.match("(.*) [\\(](.*) - (.*)[\\)]");
                fullName = playerMatch[1];
                playerTeam = playerMatch[2];
                playerPosition = playerMatch[3];
            }
            else {
                fullName = player.children[2].innerText;
            }
            let playerId;
            try {
                playerId = parseInt(player.children[2].firstChild.href.split("/").pop());
            }
            catch {
                playerId = null;
            }
            let price = null;
            if (isAuction) {
                price = parseInt(player.children[3].innerText.match(/(\d+)/)[0]);
            }

            teamDraft.Players.push({
                Round: round,
                DraftPosition: draftPos,
                FullName: fullName,
                PlayerPosition: playerPosition,
                PlayerYahooTeamAbbr: playerTeam,
                PlayerId: playerId,
                Price: price,
                IsKeeper: false,
            });
        }

        leagueDraft.Teams.push(teamDraft);
    }
    console.save(leagueDraft, `${seasonYear}_draft.json`);
    //console.log(leagueDraft);
}

scrapDraft();