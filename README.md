Email sa zadatkom sam dobio dok sam se vraćao ka stanu pročitao ga i šetavši razmišljao o problemu.
Najpre sam razmišljao o reprezentaciji oblika i odabiru strukture podataka za to, te sam se brzo odlučio za *listu dvodimenzionih vektora*.
Ovo je odlučno mesto da kažem zašto sam se odlučio za rad u C# a to je rigoroznost u pisanju koda u odnosu na JS koji je takodje primamljiva opcija zbog brzog i lakog razvoja GUI-a;

Kako mi je linearna algebra uvek bila draga (iz nekih mazohističkih razloga) brzo sam implementirao klasu za reprezentaciju 2D vektora kao i nekih osnovnih operacija.
Svestan sam da postoji NuGet gde je sve odrađeno efikasnije, no kako je cilj projekta da demonstriram svoje znanje odlučio sam se za ovaj put.

Kada sam krenuo sa radom najpre sam istraživao o osobinama konveksnih mnogouglova i jedna od njih mi je najviše privukla pažnju.
Naime svaka tačka koja se nalazi unutar konveksnog mnogougla ima osobinu da se nalazi sa iste strane svih stranica tog mnogougla.
Drugim rečima ukoliko bi se kretali u jednom smeru duž ivica mnogougla tačke unutar njega bi nam uvek bile sa jedne strane.
Određivanje sa koje se strane tačka nalazi se svodi na znak vektorskog prozvoda (*AB* x *AP*) gde je *AB* vektor jedne od stranica dok je *AP* vektor od početka te stranice pa do ispitivane taćke.

Pošao sam od pretpostavke da su ivice mnogougla u opštem slučaju unošene nasumično kako bih sebi jos malo otežao život. 
Tako da je prvi korak bio sortiranje temena mnogougla u matematicki pozitivnom smeru kako bih uopšte mogao da konstruišem ivice.

Nakon sortiranja linearna provera da su svi znaci vektorskog proizvoda istog znaka je odrađena na već objašnjen način (*u linearnom vremenu*).

Pripremio sam jedan DEMO koji će funkcionisati samo na Widows platformi i verujem da je VS22 potreban.

Subota je jutro, i šaljem vam trenutno opisanu verziju koda. Ukoliko mi vreme dopusti narednih dana (do vašeg javljanja) radiću na kodu.

Izmedju ponedeljka i srede (uz pomoć prijatelja) uspeo sam kreirati GUI u Xamarin.Forms.
GUI me je inspirisao da kreiram validaciju da li je proizvoljan mnogougao konveksan što je odrađeno bez većih poteškoća(doduše na poprilično neefikasan način).

U planu je kreiranje *undo* dugmeta.

Naredni korak je postavka aplikacije na Google GameStore kako bi bila pristušačna svima.



 
