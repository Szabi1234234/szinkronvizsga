
 function olvas(mit){
        let file = mit.files[0];
        let olvaso = new FileReader();

        olvaso.readAsText(file);

        olvaso.onload = function(){
            let tartalom = olvaso.result;
            console.log(tartalom);

            class Hegycsucs{
                constructor(nev, hegyseg, magas){
                    this.nev = nev;
                    this.hegyseg = hegyseg;
                    this.magas = magas;
                }
            }

            let hegyek = [];
            let sorok = tartalom.split("\n");
            for(let i = 1; i < sorok.length; i++){
                let darabok = sorok[i].split(";");
                let h = new Hegycsucs(darabok[0], darabok[1], parseInt(darabok[2]));
                hegyek.push(h);
            }
            console.log(hegyek);
            
            console.log("Hegyek száma " + hegyek.length);

            let osszeg = 0;
            for (const h of hegyek) {
                osszeg += h.magas;
            }

            console.log("A hegyek magasságának átlaga " + osszeg / hegyek.length);

            let max = hegyek[0];
            for (const h of hegyek) {
                if (h.magas > max.magas){
                    max = h;
                }
            }

            console.log("Legmagsabb hegy:")
            console.log(max.nev);
            console.log(max.hegyseg);
            console.log(max.magas);

            

        }
    }