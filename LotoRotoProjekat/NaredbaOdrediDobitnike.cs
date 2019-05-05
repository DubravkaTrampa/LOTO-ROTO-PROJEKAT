using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LotoRotoProjekat
{
    public class NaredbaOdrediDobitnike
    {
        //PREMESTENA JE U PROCEDURU U SQL-U PA NAM NIJE POTREBNA
        public const string NAREDBA =
            "WITH "+
"poslednje_kolo AS "+
    "(SELECT pk_kola_id, datum, dobitna_kombinacija_id "+
   " FROM LotoRotoNovo.dbo.Kola"+
   " WHERE datum ="+
        "(SELECT MAX(datum)"+
           " FROM LotoRotoNovo.dbo.Kola)"+
	"),"+

"dobitna_kombinacija AS"+
   " (SELECT*"+
   " FROM LotoRotoNovo.dbo.Kombinacije"+
   " WHERE kombinacija_id ="+
       " (SELECT dobitna_kombinacija_id"+
      "  FROM poslednje_kolo)"+
	"),"+

"tiketi_poslednjeg_kola AS"+
   " (SELECT*"+
   " FROM LotoRotoNovo.dbo.Tiketi"+
    " WHERE fk_kola_id ="+
     "   (SELECT pk_kola_id"+
      "  FROM poslednje_kolo)"+
	"),"+

"kombinacije_sa_tiketa AS"+
   " (SELECT*"+
   " FROM LotoRotoNovo.dbo.Kombinacije"+
   " WHERE kombinacija_id IN"+

        " (SELECT tiket_kombinacija_id"+

       " FROM tiketi_poslednjeg_kola)"+
	"),"+

"lista_pogodaka AS"+
   " (SELECT kt.broj, kt.kombinacija_id"+
 "   FROM"+

    " dobitna_kombinacija dk"+

  "  INNER JOIN kombinacije_sa_tiketa kt ON dk.broj = kt.broj),"+

"rezultat_kola AS"+
   " (SELECT kombinacija_id, COUNT(*) AS vrsta_pogotka"+
   " FROM lista_pogodaka"+
    " GROUP BY kombinacija_id)"+

" SELECT pk.pk_kola_id, pk.datum, pk.dobitna_kombinacija_id, rk.kombinacija_id, rk.vrsta_pogotka," +
            " t.pk_tiketi_id, k.ime, k.prezime, k.fk_racuni_id"+
" FROM rezultat_kola rk"+
" INNER JOIN LotoRotoNovo.dbo.Tiketi t ON t.tiket_kombinacija_id = rk.kombinacija_id"+
" INNER JOIN LotoRotoNovo.dbo.Korisnici k ON K.pk_korisnici_id = t.fk_korisnici_id"+
" CROSS JOIN poslednje_kolo pk"+
" WHERE rk.vrsta_pogotka > 3"+
" ORDER BY rk.kombinacija_id;";

    }
}