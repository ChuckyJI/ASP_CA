namespace CAProj.Models;

public class Orders
{
    public int orderQty { get; set; }
    public float orderPrice { get; set; }
    public float orderReview { get; set; }
    public DateTime orderTime { get; set; }
    public string orderName { get; set; }
    public string itemID { get; set; }
    public string userName { get; set; }
}