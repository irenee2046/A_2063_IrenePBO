using System;
using System.Collections.Generic;


interface IPeminjaman
{
    void PinjamBuku(int index);
    void KembalikanBuku(int index);
    void LihatBukuDipinjam();
}

abstract class Buku
{
    
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int Tahun { get; set; }
    public bool Dipinjam { get; set; }

    public Buku(string judul, string penulis, int tahun)
    {
        Judul = judul;
        Penulis = penulis;
        Tahun = tahun;
        Dipinjam = false;
    }


    public abstract void TampilkanInfo();
}

class BukuFiksi : Buku
{
    public BukuFiksi(string judul, string penulis, int tahun) : base(judul, penulis, tahun) { }

    public override void TampilkanInfo()
    {
        Console.WriteLine($"[Fiksi] {Judul} oleh {Penulis} ({Tahun}) - {(Dipinjam ? "Dipinjam" : "Tersedia")}");
    }
}

class BukuNonFiksi : Buku
{
    public BukuNonFiksi(string judul, string penulis, int tahun) : base(judul, penulis, tahun) { }

    public override void TampilkanInfo()
    {
        Console.WriteLine($"[Non-Fiksi] {Judul} oleh {Penulis} ({Tahun}) - {(Dipinjam ? "Dipinjam" : "Tersedia")}");
    }
}

class Majalah : Buku
{
    public Majalah(string judul, string penulis, int tahun) : base(judul, penulis, tahun) { }

    public override void TampilkanInfo()
    {
        Console.WriteLine($"[Majalah] {Judul} Edisi {Tahun} - {(Dipinjam ? "Dipinjam" : "Tersedia")}");
    }
}

// Kelas utama yang mengatur perpustakaan
class Perpustakaan : IPeminjaman
{
    private List<Buku> daftarBuku = new List<Buku>();
    private List<Buku> bukuDipinjam = new List<Buku>();
    private const int maxPinjam = 3;

    public void TambahBuku()
    {
        Console.WriteLine("Pilih jenis buku: ");
        Console.WriteLine("1. Fiksi");
        Console.WriteLine("2. Non-Fiksi");
        Console.WriteLine("3. Majalah");
        Console.Write("Masukkan pilihan (1-3): ");
        string pilihan = Console.ReadLine();

        Console.Write("Judul: ");
        string judul = Console.ReadLine();
        Console.Write("Penulis: ");
        string penulis = Console.ReadLine();
        Console.Write("Tahun terbit: ");
        int tahun = int.Parse(Console.ReadLine());

        Buku bukuBaru;

        if (pilihan == "1")
        {
            bukuBaru = new BukuFiksi(judul, penulis, tahun);
        }
        else if (pilihan == "2")
        {
            bukuBaru = new BukuNonFiksi(judul, penulis, tahun);
        }
        else if (pilihan == "3")
        {
            bukuBaru = new Majalah(judul, penulis, tahun);
        }
        else
        {
            Console.WriteLine("Pilihan tidak valid.");
            return;
        }

        daftarBuku.Add(bukuBaru);
        Console.WriteLine("Buku berhasil ditambahkan!\n");
    }


    public void LihatDaftarBuku()
    {
        Console.WriteLine("\nDaftar Buku:");
        if (daftarBuku.Count == 0)
        {
            Console.WriteLine("Belum ada buku.");
            return;
        }

        for (int i = 0; i < daftarBuku.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            daftarBuku[i].TampilkanInfo();
        }
        Console.WriteLine();
    }

    