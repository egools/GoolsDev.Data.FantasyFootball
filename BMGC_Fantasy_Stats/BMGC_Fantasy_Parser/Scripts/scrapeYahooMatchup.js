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

function scrapMatchup() {
    let leagueName = document.querySelector("#league-info").firstElementChild.querySelector(".Ta-end").innerText;
    let seasonYear = document.querySelector("#league-info").firstElementChild.querySelector(".D-ib").innerText.match(/(20\d\d).*? Season/)[1];
    let week = document.querySelector("#fantasy header span").innerText.match(/Week (\d+)/)[1];
    let managerNames = Array.from(document.querySelectorAll("#matchup-header .user-id")).map(elm => elm.innerHTML);
    let teamNames = Array.from(document.querySelectorAll("#matchup-header a.F-link")).map(elm => elm.innerHTML);

    let leftTeam = {
        Manager: managerNames[0],
        TeamName: teamNames[0],
        Players: []
    };
    let rightTeam = {
        Manager: managerNames[1],
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
        let pointsScoredElements = row.querySelectorAll(".Fw-b div");
        let ysIds = Array.from(row.querySelectorAll(".player-status a")).map(elm => elm.dataset.ysPlayerid);
        let fantasyPosition = row.querySelector("td:nth-child(6) div").innerHTML;
        let projectedLeft = row.querySelector("td:nth-child(3) div").innerHTML;
        let projectedRight = row.querySelector("td:nth-child(9) div").innerHTML;
        let shortNames = row.querySelectorAll(".player .ysf-player-name a");

        let statBlockLeft = document.querySelector(`#pps-${ysIds[0]}`);
        let statBlockRight = document.querySelector(`#pps-${ysIds[1]}`);
        let fullNameLeft = statBlockLeft.querySelector("h2").innerHTML.replace(" Stat Breakdown", "");
        let fullNameRight = statBlockRight.querySelector("h2").innerHTML.replace(" Stat Breakdown", "");

        let leftStats = Array.from(statBlockLeft.querySelectorAll("tbody tr")).map(elm =>
            ({
                StatText: elm.querySelectorAll("td")[0].innerText,
                Points: parseFloat(elm.querySelectorAll("td")[2].innerText)
            }));
        let rightStats = Array.from(statBlockRight.querySelectorAll("tbody tr")).map(elm =>
            ({
                StatText: elm.querySelectorAll("td")[0].innerText,
                Points: parseFloat(elm.querySelectorAll("td")[2].innerText)
            }));

        let leftMatchupPlayer = {
            FullName: fullNameLeft,
            PlayerId: parseInt(ysIds[0]),
            MatchupPosition: fantasyPosition,
            PointsScored: parseFloat(pointsScoredElements[0].innerText),
            ProjectedPoints: parseFloat(projectedLeft),
            ShortName: shortNames[0].innerHTML,
            Stats: leftStats
        };

        let rightMatchupPlayer = {
            FullName: fullNameRight,
            PlayerId: parseInt(ysIds[1]),
            MatchupPosition: fantasyPosition,
            PointsScored: parseFloat(pointsScoredElements[1].innerText),
            ProjectedPoints: parseFloat(projectedRight),
            ShortName: shortNames[1].innerHTML,
            Stats: rightStats
        };

        leftTeam.Players.push(leftMatchupPlayer);
        rightTeam.Players.push(rightMatchupPlayer);
    }

    console.save(matchup, `${seasonYear}_Week${week}_${leftTeam.Manager.replace(/ /, "")}-${rightTeam.Manager.replace(/ /, "")}.json`);
    //console.log(matchup);
}

scrapMatchup();