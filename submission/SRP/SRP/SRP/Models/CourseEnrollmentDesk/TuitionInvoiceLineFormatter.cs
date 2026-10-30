namespace SRP.Models;

public sealed class TuitionInvoiceLineFormatter
{
    public string Format(string courseCode, decimal tuition, bool seated)
    {
        if (!seated) return $"{courseCode},WAITLIST,0.00";
        var vat = Math.Round(tuition * 0.14m, 2);
        return $"{courseCode},TUITION,{tuition:0.00},VAT,{vat:0.00},TOTAL,{(tuition + vat):0.00}";
    }
}