using System;
using System.Collections.Generic;
using System.Text;

namespace Celin.W01012A
{
    public class FormData : AIS.FormData<AIS.Row>
    {
        public AIS.FormField<string> z_AC20_411 { get; set; }
        public AIS.FormField<string> z_EXCHG_300 { get; set; }
        public AIS.FormField<string> z_YEARSTAR_303 { get; set; }
        public AIS.FormField<string> z_REVRNG_305 { get; set; }
        public AIS.FormField<string> z_AC17_402 { get; set; }
        public AIS.FormField<string> z_AC18_405 { get; set; }
        public AIS.FormField<string> z_AC19_408 { get; set; }
        public AIS.FormField<string> z_TICKER_298 { get; set; }
        public AIS.FormField<string> z_ALPH_28 { get; set; }
        public AIS.FormField<int> z_AN8_21 { get; set; }
        public AIS.FormField<string> z_MLNM_38 { get; set; }
        public AIS.FormField<string> z_AT1_36 { get; set; }
        public AIS.FormField<string> z_TAX_34 { get; set; }
        public AIS.FormField<string> z_CLASS01_284 { get; set; }
        public AIS.FormField<string> z_AC15_396 { get; set; }
        public AIS.FormField<string> z_AC16_399 { get; set; }
        public AIS.FormField<string> z_ALKY_32 { get; set; }
        public AIS.FormField<string> z_ADD4_46 { get; set; }
        public AIS.FormField<string> z_CLASS04_290 { get; set; }
        public AIS.FormField<string> z_CLASS05_292 { get; set; }
        public AIS.FormField<string> z_CLASS03_286 { get; set; }
        public AIS.FormField<string> z_CLASS02_288 { get; set; }
        public AIS.FormField<string> z_ADD3_44 { get; set; }
        public AIS.FormField<string> z_ADD2_42 { get; set; }
        public AIS.FormField<string> z_ADD1_40 { get; set; }
        public AIS.FormField<string> z_COUN_58 { get; set; }
        public AIS.FormField<string> z_CTR_56 { get; set; }
        public AIS.FormField<string> z_AC10_381 { get; set; }
        public AIS.FormField<string> z_CM_140 { get; set; }
        public AIS.FormField<string> z_SBLI_132 { get; set; }
        public AIS.FormField<string> z_AC08_375 { get; set; }
        public AIS.FormField<string> z_TAXC_134 { get; set; }
        public AIS.FormField<string> z_SIC_136 { get; set; }
        public AIS.FormField<string> z_AC09_378 { get; set; }
        public AIS.FormField<string> z_LNGP_138 { get; set; }
        public AIS.FormField<string> z_ADDS_54 { get; set; }
        public AIS.FormField<string> z_CTY1_52 { get; set; }
        public AIS.FormField<string> z_ADDZ_50 { get; set; }
        public AIS.FormField<string> z_ATR_67 { get; set; }
        public AIS.FormField<string> z_AC13_390 { get; set; }
        public AIS.FormField<string> z_AC14_393 { get; set; }
        public AIS.FormField<string> z_AC11_384 { get; set; }
        public AIS.FormField<string> z_AC12_387 { get; set; }
        public AIS.FormField<string> z_TX2_146 { get; set; }
        public AIS.FormField<string> z_TXCT_148 { get; set; }
        public AIS.FormField<string> z_ATP_64 { get; set; }
        public AIS.FormField<string> z_MCU_62 { get; set; }
        public AIS.FormField<string> z_AC03_360 { get; set; }
        public AIS.FormField<string> z_AC27_481 { get; set; }
        public AIS.FormField<string> z_AC24_472 { get; set; }
        public AIS.FormField<string> z_AC01_354 { get; set; }
        public AIS.FormField<string> z_AC25_475 { get; set; }
        public AIS.FormField<string> z_AC02_356 { get; set; }
        public AIS.FormField<string> z_AC26_478 { get; set; }
        public AIS.FormField<string> z_AC30_490 { get; set; }
        public AIS.FormField<string> z_ATPR_130 { get; set; }
        public AIS.FormField<string> z_AT3_251 { get; set; }
        public AIS.FormField<string> z_AC07_372 { get; set; }
        public AIS.FormField<string> z_AC04_363 { get; set; }
        public AIS.FormField<string> z_AC28_484 { get; set; }
        public AIS.FormField<string> z_AC05_366 { get; set; }
        public AIS.FormField<string> z_AC29_487 { get; set; }
        public AIS.FormField<string> z_AC06_369 { get; set; }
        public AIS.FormField<string> z_ATE_129 { get; set; }
        public AIS.FormField<int> z_AN86_330 { get; set; }
        public AIS.FormField<string> z_DUNS01_456 { get; set; }
        public AIS.FormField<string> z_DUNS02_457 { get; set; }
        public AIS.FormField<string> z_DUNS03_458 { get; set; }
        public AIS.FormField<string> z_AC21_463 { get; set; }
        public AIS.FormField<string> z_AC22_466 { get; set; }
        public AIS.FormField<string> z_AC23_469 { get; set; }
        public AIS.FormField<int> z_GROWTHR_311 { get; set; }
        public AIS.FormField<int> z_NOE_313 { get; set; }
        public AIS.FormField<string> z_AEMPGP_316 { get; set; }
        public AIS.FormField<int> z_PA8_318 { get; set; }
        public AIS.FormField<int> z_AN82_320 { get; set; }
        public AIS.FormField<int> z_AN81_322 { get; set; }
        public AIS.FormField<string> z_AT2_444 { get; set; }
        public AIS.FormField<int> z_AN83_324 { get; set; }
        public AIS.FormField<int> z_AN84_326 { get; set; }
        public AIS.FormField<int> z_AN85_328 { get; set; }
    }
    public class Response : AIS.FormResponse
    {
        public AIS.Form<FormData> fs_P01012_W01012A { get; set; }
        public AIS.Form<AIS.FormData<W01012B.Row>> fs_P01012_W01012B { get; set; }
    }
}
