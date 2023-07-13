namespace CAProj.Models;

public class CartLine
{
    public string cartName { get; set; }
    public float cartPrice { get; set; }
    // public string cartID { get; set; }
    public int cartQuantity  { get; set; }

    public CartLine(string cartName, float cartPrice, int cartQuantity)
    {
        this.cartName = cartName;
        this.cartPrice = cartPrice;
        // cartID = cartId;
        this.cartQuantity = cartQuantity;
    }

    public CartLine()
    {
        
    }
}