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
    let leagueName = document.querySelector("#league-info").firstElementChild.querySelector(".Ta-end").innerText;
    let seasonYear = document.querySelector("#league-info").firstElementChild.querySelector(".D-ib").innerText.match(/(20\d\d).*? Season/)[1];
    let isAuction = document.querySelector("td.cost") !== null;

    let leagueDraft = {
        LeagueName: leagueName,
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
            let fullName = player.children[2].innerText;
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
                PlayerId: playerId,
                Price: price
            });
        }

        leagueDraft.Teams.push(teamDraft);
    }
    console.save(leagueDraft, `${seasonYear}_draft.json`);
    //console.log(leagueDraft);
}

scrapDraft();