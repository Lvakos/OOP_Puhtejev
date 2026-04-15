using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_Puhtejev
{
    public enum Õppevorm
    {
        Päevane,
        Kaugõpe,
        Ekstern,
        AkadeemilinePuhkus
    }

    public enum TööTüüp
    {
        Palk,
        Toetus
    }
    public interface ITööline
    {
        TööTüüp VäljamakseTüüp { get; set; }
        double ArvutaPalk();
    }
}
