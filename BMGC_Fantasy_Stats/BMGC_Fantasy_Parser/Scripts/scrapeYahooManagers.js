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
    let leagueName = document.querySelector("#league-info").firstElementChild.querySelector(".Ta-end").innerText;
    let seasonYear = document.querySelector("#league-info").firstElementChild.querySelector(".D-ib").innerText.match(/(20\d\d).*? Season/)[1];

    let leagueManagers = {
        LeagueName: leagueName,
        SeasonYear: seasonYear,
        Managers: []
    };

    let managers = document.querySelectorAll("#teams tbody tr");
    let headers = Array.from(document.querySelectorAll("#teams thead th")).map(elm => elm.innerText);
    for (const manager of managers) {
        let cols = Array.from(manager.querySelectorAll("td")).map(elm => elm.innerText);
        leagueManagers.Managers.push({
            TeamName: cols[headers.indexOf("Team Name")],
            Manager: cols[headers.indexOf("Manager")],
            MovesMade: parseInt(cols[headers.indexOf("Moves")]),
            TradesMade: parseInt(cols[headers.indexOf("Trades")])
        });
    }
    console.save(leagueManagers, `${seasonYear}_managers.json`);
    //console.log(leagueManagers);
}

scrapManagers();