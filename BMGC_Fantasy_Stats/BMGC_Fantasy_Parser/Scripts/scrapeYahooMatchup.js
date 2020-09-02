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

function scrapeMatchup() {
    let leagueName = document.querySelector("#league-info").firstElementChild.querySelector(".Ta-end").innerText;
    let seasonYear = document.querySelector("#league-info").firstElementChild.querySelector(".D-ib").innerText.match(/(20\d\d).*? Season/)[1];
    let week = document.querySelector("#fantasy header span").innerText.match(/Week (\d+)/)[1];
    let managerNames = Array.from(document.querySelectorAll("#matchup-header .user-id")).map(elm => elm.innerText);
    let teamNames = Array.from(document.querySelectorAll("#matchup-header a.F-link")).map(elm => elm.innerText);
    let leftUrl = document.querySelector("#felo-overlay > div > div.Ptop-xl > table > thead > tr > th.Ta-start.Whs-nw.Fw-b.F-reset.Fz-sm.Wpx-200.D-ib.Ell.Px-xl > a").href
    let rightUrl = document.querySelector("#felo-overlay > div > div.Ptop-xl > table > thead > tr > th.Ta-start.Whs-nw.Fw-b.F-reset.Fz-sm.Wpx-200.D-ib.Ell.Px-xl > a").href
    let leftYahooId = leftUrl.substr(leftUrl.lastIndexOf("/") + 1, leftUrl.lastIndexOf("?") - leftUrl.lastIndexOf("/") - 1);
    let rightYahooId = rightUrl.substr(rightUrl.lastIndexOf("/") + 1, rightUrl.lastIndexOf("?") - rightUrl.lastIndexOf("/") - 1);

    let leftTeam = {
        Manager: managerNames[0],
        YahooManagerId: leftYahooId,
        TeamName: teamNames[0],
        Players: []
    };
    let rightTeam = {
        Manager: managerNames[1],
        YahooManagerId: rightYahooId,
        TeamName: teamNames[1],
        Players: []
    };

    let matchup = {
        LeagueName: leagueName,
        SeasonYear: seasonYear,
        Week: week,
        LeftTeam: leftTeam,
        RightTeam: rightTeam
    };

    let players = document.querySelectorAll("#matchups #statTable1 tbody tr:not(.Last), #bench-table #statTable2 tbody tr:not(.Last)");
    for (let i = 0; i < players.length; i++) {
        let row = players[i];
        let cols = row.querySelectorAll("td:not(.Hidden)");
        let fantasyPosition = cols[4].innerText;

        if (cols[1].innerText.trim() !== "(Empty)") {
            let ysId = cols[1].querySelector(".player-status a").dataset.ysPlayerid;
            let shortName = cols[1].querySelector(".ysf-player-name a").innerText;
            let projected = cols[2].innerText;
            let pointsScored = cols[3].innerText;

            let statBlock = document.querySelector(`#pps-${ysId}`);
            let fullName = statBlock.querySelector("h2").innerHTML.replace(" Stat Breakdown", "");
            let stats = Array.from(statBlock.querySelectorAll("tbody tr")).map(elm =>
                ({
                    StatText: elm.querySelector("td:nth-child(1)").innerText,
                    Points: parseFloat(elm.querySelector("td:nth-child(3)").innerText)
                }));

            let matchupPlayer = {
                FullName: fullName,
                PlayerId: parseInt(ysId),
                MatchupPosition: fantasyPosition,
                PointsScored: parseFloat(pointsScored),
                ProjectedPoints: parseFloat(projected),
                ShortName: shortName,
                Stats: stats
            };
            leftTeam.Players.push(matchupPlayer);
        }

        if (cols[7].innerText.trim() !== "(Empty)") {

            let ysId = cols[7].querySelector(".player-status a").dataset.ysPlayerid;
            let shortName = cols[7].querySelectorAll(".ysf-player-name a").innerText;
            let projected = cols[6].innerText;
            let pointsScored = cols[5].innerText;

            let statBlock = document.querySelector(`#pps-${ysId}`);
            let fullName = statBlock.querySelector("h2").innerHTML.replace(" Stat Breakdown", "");
            let stats = Array.from(statBlock.querySelectorAll("tbody tr")).map(elm =>
                ({
                    StatText: elm.querySelector("td:nth-child(1)").innerText,
                    Points: parseFloat(elm.querySelector("td:nth-child(3)").innerText)
                }));

            let matchupPlayer = {
                FullName: fullName,
                PlayerId: parseInt(ysId),
                MatchupPosition: fantasyPosition,
                PointsScored: parseFloat(pointsScored),
                ProjectedPoints: parseFloat(projected),
                ShortName: shortName,
                Stats: stats
            };
            rightTeam.Players.push(matchupPlayer);
        }

    }

    console.save(matchup, `${seasonYear}_Week${week}_${leftTeam.Manager.replace(/ /, "")}-${rightTeam.Manager.replace(/ /, "")}.json`);
    //console.log(matchup.LeftTeam.Players.filter(p => p.MatchupPosition != "BN").map(p => p.ProjectedPoints).reduce((tot, p) => { return tot + p }));
}

scrapeMatchup();