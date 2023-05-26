using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Product
{
    static int _idCounter = 1;
    public int Id { get; private set; }
    public string Barcode { get; set; }
    public int PurchasePrice { get; set; }
    public int SalePrice { get; set; }
    public int DiscountPrice { get; set; }
    public DateTime CreationDate { get; private set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime DeletionDate { get; private set; }
    public DateTime UpdateDate { get; private set; }
    public static ArrayList db = new ArrayList();

    public Product(string barcode, int purchasePrice, int salePrice, int discountPrice, string brand, string model)
    {
        Barcode = barcode;
        PurchasePrice = purchasePrice > 0 ? purchasePrice : throw new Exception("Purchase price can not be less than or equal to zero.");
        SalePrice = salePrice >= purchasePrice ? salePrice : throw new Exception("Sale price can not be less than rurchase price.");
        DiscountPrice = discountPrice > 0 ? discountPrice : throw new Exception("Discount price can not be less than or equal to zero.");
        CreationDate = DateTime.Now;
        Brand = brand;
        Model = model;
        Id = _idCounter;
        _idCounter++;

        for (int i = 0; i < db.Count; i++)
        {
            Product BarcodeChecker = (Product)db[i];
            if (this.Barcode == BarcodeChecker.Barcode)
            {
                throw new Exception($"Warning!!! Barcode duplication. Check Id:{this.Id}");
            }
        }

        db.Add(this);
    }

    public void UpdateBrand(string brand)
    {
        Brand = brand;
        UpdateDate = DateTime.Now;
    }
    public void UpdateModel(string model)
    {
        Model = model;
        UpdateDate = DateTime.Now;
    }
    public void UpdateBarcode(string barcode)
    {
        Barcode = barcode;
        UpdateDate = DateTime.Now;
    }
    public void UpdatePuchasePrice(int purchasePrice)
    {
        PurchasePrice = purchasePrice;
        UpdateDate = DateTime.Now;
    }
    public void UpdateSalePrice(int salePrice)
    {
        SalePrice = salePrice;
        UpdateDate = DateTime.Now;
    }
    public void UpdateDiscountPrice(int discountPrice)
    {
        DiscountPrice = discountPrice;
        UpdateDate = DateTime.Now;
    }
    public void Delete()
    {
        IsDeleted = true;
        DeletionDate = DateTime.Now;
        IsDeleted = true;
    }

    public static void GetAll()
    {
        foreach (Product item in db)
        {
            if (item.IsDeleted == false)
            {
                System.Console.WriteLine($"{item.Id} exists in database.");
            }
        }
    }
}
public class Laptop : Product
{
    public string CPU { get; set; }
    public string RAM { get; set; }
    public string GPU { get; set; }
    public Laptop(string barcode, int purchasePrice, int salePrice, int discountPrice, string brand, string model, string cpu, string ram, string gpu)
: base(barcode, purchasePrice, salePrice, discountPrice, brand, model)
    {
        CPU = cpu;
        RAM = ram;
        GPU = gpu;
    }

}
public class TV : Product
{

    public bool SmartTv { get; set; }
    public int Inch { get; set; }
    public bool HDMI { get; set; }
    public TV(string barcode, int purchasePrice, int salePrice, int discountPrice, string brand, string model, bool smartTv, int inch, bool hdmi)
: base(barcode, purchasePrice, salePrice, discountPrice, brand, model)
    {
        SmartTv = smartTv;
        Inch = inch;
        HDMI = hdmi;
    }
}
