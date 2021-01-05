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

function scrapManagers() {
    let leagueTitleMatch = document.querySelector("#league-info").firstElementChild.querySelector(".Ta-end").innerText.match("(.*) \\(ID# (\\d+)\\)");
    let leagueName = leagueTitleMatch[1];
    let yId = leagueTitleMatch[2];
    let seasonYearMatch = document.querySelector("#league-info").firstElementChild.innerText.match(/(20\d\d).*? Season/);
    let seasonYear = seasonYearMatch ? seasonYearMatch[1] : new Date().getFullYear();

    let leagueManagers = {
        LeagueName: leagueName,
        YahooLeagueId: yId,
        SeasonYear: seasonYear,
        Managers: []
    };

    let managers = document.querySelectorAll("#teams tbody tr");
    let headers = Array.from(document.querySelectorAll("#teams thead th")).map(elm => elm.innerText);
    for (const manager of managers) {
        let cols = Array.from(manager.querySelectorAll("td")).map(elm => elm.innerText);
        let yid = manager.querySelector("span.user-id a").href.split("/").pop();
        leagueManagers.Managers.push({
            TeamName: cols[headers.indexOf("Team Name")],
            Manager: cols[headers.indexOf("Manager")],
            MovesMade: parseInt(cols[headers.indexOf("Moves")]),
            TradesMade: parseInt(cols[headers.indexOf("Trades")]),
            YahooManagerId: yid
        });
    }
    console.save(leagueManagers, `${seasonYear}_managers.json`);
    //console.log(leagueManagers);
}

scrapManagers();