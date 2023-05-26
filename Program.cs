using System;
using System.Collections;
using Microsoft.Extensions.Primitives;

/*
            * Productin database elave edilmesi, silinmesi, redakte edilmesi,butun mehsullarin gosterilmesi.
            * Taski yerine yetirerken kecdiyimiz yeni movzulari
            * ehate etmesine fikir verilmelidir. 2 mehsul tipimiz olacaq biri Tv digeri ise Laptop.
            *
            *
            * Product
            * Id : sistem terefinden genarete olunacaq , set oluna bilmez, 1-den baslayaraq artan olmalidir.
            * Barcode : DataBase-de eyni barcode-a sahip mehsulun olub olmamasi yoxlanmalidir.
            * Purchase price : mehsulun alis qiymeti 0-dan kicik ve ya beraber ola bilmez.
            * Sale price : mehsulun satis qiymeti alis qiymetinden kicik ola bilmez.
            * Discount price : mehsulun endirimli qiymeti 0-dan kicik ve ya beraber ola bilmez.
            * CreateDate : set edile bilmez.
            * Brand
            * Model
            * IsDeleted (bool)
            * DeletedDate : set edile bilmez
            * UpdatedDate : set edile bilmez
             *
             *
            * *Laptop
            * cpu
            * ram
            * videoCard
            *
            * * Tv
            * SmartTv (bool)
            * Inch
            * HDMi (bool)
            *
            * *Database 
            * Add : mehsulun elave edilmesi
            * Remove : mehsulun silinmesi(sadece isDeleted statusu redakte edilir.)
            * GetAll : IsDeleted statusu false olanlarin siyahisinin gosterilmesi 
            * Update : Mehsulun Brand,Model,Discount price,Sale price,Purchase price, Barcode xususiyyetleri redakte edilecek.
            *
            *
            */

class Program
{
    static void Main(string[] args)
    {
        Product product1 = new Product("1234567890", 100, 101, 99, "HP", "Probook");
        Product product2 = new Product("1234567891", 100, 101, 99, "HP", "Probook");
        Product product3 = new Product("1234567892", 100, 101, 99, "HP", "Probook");

        Laptop laptop1 = new Laptop("1234567893", 100, 101, 99, "HP", "Probook", "dual-core", "8GB", "RTX 3060");
        Laptop laptop2 = new Laptop("1234567894", 100, 101, 99, "Asus", "Probook", "dual-core", "8GB", "RTX 3060");
        TV tv1 = new TV("1234567895", 100, 101, 99, "Samsung", "L500", true, 64, true);
        TV tv2 = new TV("1234567896", 100, 101, 99, "LG", "A300", true, 64, true);
        TV tv3 = new TV("1234567897", 100, 101, 99, "Beko", "Q500", true, 64, true);

        product1.Delete();
        product2.Delete();
        tv2.Delete();

        Product.GetAll();

    }
}