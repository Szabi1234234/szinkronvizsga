   class Jelolt
    {
        constructor(korzet, szavazatok, vezeteknev, keresztnev, part)
        {
            this.korzet = korzet;
            this.szavazatok = szavazatok;
            this.vezeteknev = vezeteknev;
            this.keresztnev = keresztnev;
            this.part = part;
        }

    }

    function olvas(mit) {
        let file = mit.files[0];
        let olvaso = new FileReader();

        olvaso.readAsText(file);
        console.log(file);
    
        olvaso.onload = function() {
            let tartalom = olvaso.result;
            let jeloltek = [];

            let sorok = tartalom.split("\r\n");

            for (let i = 0; i< sorok.length; i++)
            {
                let adatok = sorok[i].split(" ");
                let j = new Jelolt(parseInt(adatok[0]), parseInt(adatok[1]), adatok[2], adatok[3], adatok[4]);
                jeloltek.push(j);

                console.log(j);

            }

            console.log("Jelöltek száma: " + jeloltek.length);

            let zepszavazatok = 0;
            for (let i = 0; i< jeloltek.length;  i++)
            {
                if(jeloltek[i].part == "ZEP") {
                    zepszavazatok += jeloltek[i].szavazatok;
                }
            }
            console.log("Zep szavazatok: " + zepszavazatok);

            let egyeskorzetmax = 0;
                let egyeskorzetmaxnev= "";

                for (let i = 0; i < jeloltek.length ; i++) {
                    if (jeloltek[i].korzet === 1) {
                        if (jeloltek[i].szavazatok > egyeskorzetmax) {
                            egyeskorzetmax = jeloltek[i].szavazatok;
                            egyeskorzetmaxnev = jeloltek[i].vezeteknev + " " + jeloltek[i].keresztnev;
                        }
                    }

                        
                }
                console.log("1-es körzet nyertese: " + egyeskorzetmaxnev);


            let zep_jeloltek = 0;
            let gyep_jeloltek = 0;
            let hep_jeloltek = 0;
            let tisz_jeloltek = 0;
            let fuggetlen_jeloltek = 0;


            for (let i = 0; i < jeloltek.length ; i++)
            {
                if(jeloltek[i].part === "ZEP") {
                    zep_jeloltek++;
                }
                else if(jeloltek[i].part === "GYEP") {
                    gyep_jeloltek++;
                }
                else if(jeloltek[i].part === "HEP") {
                    hep_jeloltek++;
                }
                else if(jeloltek[i].part === "TISZ") {
                    tisz_jeloltek++;
                }
                else if(jeloltek[i].part === "-") {
                    fuggetlen_jeloltek++;
                }
            }

            console.log("ZEP jelöltek száma: " + zep_jeloltek);
            console.log("GYEP jelöltek száma: " + gyep_jeloltek);
            console.log("HEP jelöltek száma: " + hep_jeloltek);
            console.log("TISZ jelöltek száma: " + tisz_jeloltek);
            console.log("Független jelöltek száma: " + fuggetlen_jeloltek);

            let fugg_jeloltek_adatok = "";

            for (let i = 0; i < jeloltek.length ; i++) {
                if(jeloltek[i].part === "-") {
                    fugg_jeloltek_adatok += jeloltek[i].vezeteknev + " " + jeloltek[i].keresztnev + " - " + jeloltek[i].szavazatok + "<br>";

                }
            
            }
            document.getElementById("fuggetlenjeloltek").innerHTML = fugg_jeloltek_adatok;

        }

   
        }

