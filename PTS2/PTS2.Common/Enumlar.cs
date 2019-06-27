using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTS2.Common
{
    public class Enumlar
    {

        public enum IzinDurum
        {
            [Description("İşleme Alındı")]
            ISLEME_ALINDI = 1,

            [Description("Onaylandı")]
            ONAYLANDI = 2,

            [Description("Reddedildi")]
            REDDEDILDI = 3
        };
        public enum IzinTipi
        {
            [Description("Yıllık İzin")]
            YILLIK_IZIN = 1,

            [Description("Raporlu İzin")]
            RAPORLU_IZIN = 2,

            [Description("Doğum izni")]
            DOGUM_IZNI = 3,

            [Description("Evlilik izni")]
            EVLILIK_IZNI = 4,

            [Description("Ölüm İzni")]
            OLUM_IZNI = 5,

            [Description("Yeni İş Arama izni")]
            YENI_IS_ARAMA_IZNI = 6
        };

    }
}
