namespace SRP.Models;

public sealed class CheckoutBasket
{
    private readonly BasketLineStore _lines = new();
    private readonly CouponDiscountCalculator _discounts = new();
    private readonly CheckoutPricingCalculator _pricing = new();
    private readonly GiftMessageFormatter _giftFormatter = new();
    private readonly PaymentAuthorizationStub _payment = new();
    private string? _couponRaw;
    private bool _giftWrap;

    public void AddLine(string sku, decimal price, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty));
        _lines.Add(sku, price, qty);
    }

    public void ApplyCouponText(string? couponText) => _couponRaw = couponText;
    public void EnableGiftWrap() => _giftWrap = true;

    public decimal SubTotal() => _pricing.SubTotal(_lines.Lines);

    public decimal DiscountAmount() => _discounts.Calculate(_couponRaw, SubTotal());

    public decimal GrandTotal() => _pricing.GrandTotal(SubTotal(), DiscountAmount(), _giftWrap);

    public string GiftMessageCard(string fromName) => _giftFormatter.Format(_lines.Lines, fromName, GrandTotal());

    public string AuthorizePaymentStub(string cardLast4) => _payment.Authorize(GrandTotal(), cardLast4, _lines.Lines.Count);
}