### EcoEnergyBBDD:

Aquesta aplicació consisteix de 3 pàgines diferents que, mitjançant **EntityFramework**, accedeixen a una base de dades per obtenir, afegir, esborrar o modificar informació.
Aquestes accions les fan mitjançant operacions CRUD (les quals es troben en mètodes a les helper classes de la carpeta CRUDs per a una millor organització del codi) relacionats 
a certes accions de RazorPages com OnPost (Insert/Update), OnPostDelete (Delete) o OnGet (Select).

A part, cal fer una observació sobre les classes que obtenen informació de la base de dades (les relacionades amb el context mitjançant el DBSet) i les que llegeixen els formularis
i els fitxers; Els dos tipus no són junts (per exemple, la que registra els consums d'aigua a la BD i la que llegeix les entrades del formulari de consums i el fitxer csv no són la 
mateixa classe) per tal de controlar la correcta lectura de fitxers i la validació per client i servidor dels formularis, a més d'assegurar la manipulació correcta de les dades 
de la BD. Bàsicament es separen les funcionalitats.

S'ha afegit tots els camps de les classes de la pràctica anterior ja que a classe es va comentar sobre la possibilitat.

Link de la documentació: https://docs.google.com/document/d/10HobswTsUQ3RXd0xFacjPw8AytcJHfx711yWdfqOgVA/edit?usp=sharing
