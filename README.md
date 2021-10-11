#UCMS Internship
Mini HR app

-o firma/company are mai multi angajati

-un angajat are nume, prenume, detalii contact, conturi (teams, whatshup, ), data angajarii, salariu, pozitie, departament,ierarhie, pontaj, alte documente, CI, concedii
	-date personale (nume, prenume, CNP, data nasterii, locul nasterii)
	-adresE- localitat, strada, numar, judet, tara (adresa din CI sau flotant) - 1 to many
	-contacte - teams, whathup, email, numar telefonserviciu, numar telefon personal - 1 to many
	-acte identitate- CI - serie, numar, valid din, expira in, emitent, 1 to many
					  pasaport
					  permis conducere
	-date bancare- cont la mai multe banci si/sau mai multe conturi la aceeasi banca					
	-persoane in intretinere					
	-unu sau mai multe contracte

-un contract are 
	-cod inregistrare
	-una sau mai multe versiuni/acte aditionale
	-o versiune/act aditional are 
		-data incepere versiune, salariu, pozitie, departament, ierarhie pozitie in cadrul firmei
		-numar act aditional
			- generare automata a numarului de act aditional - la schimbare de salariu , functia, departamentul
			
-upload documente angajat

-raport la nivel de firma   - rapoarte lista angajati
							- salar mediu firma
							- angajatii carora le expira actul de identitate in urmaoarea luna
		

