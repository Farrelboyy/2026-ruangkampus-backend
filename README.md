# Sistem Peminjaman Ruangan - Backend Service

Repositori ini berisi kode sumber sisi server (*backend*) untuk Sistem Peminjaman Ruangan Kampus. Proyek ini dikembangkan menggunakan framework **ASP.NET Core 8.0** dengan arsitektur REST API.

Tujuan utama dari layanan ini adalah menyediakan *endpoints* untuk autentikasi pengguna dan manajemen peminjaman ruangan (CRUD) yang akan dikonsumsi oleh aplikasi Frontend dan Mobile.

## 🛠 Teknologi yang Digunakan
* **Framework:** ASP.NET Core 8.0
* **Database:** SQL Server
* **ORM:** Entity Framework Core
* **Authentication:** JWT (JSON Web Token) & BCrypt Hashing
* **Documentation:** Swagger UI

## 📋 Fitur Implementasi
1.  **Manajemen Autentikasi:** Registrasi dan Login pengguna dengan keamanan token.
2.  **Manajemen Peminjaman (Room Loans):**
    * *Create*: Pengajuan peminjaman baru dengan validasi ketersediaan.
    * *Read*: Menampilkan riwayat peminjaman.
    * *Update*: Pembaruan data peminjaman (status pending).
    * *Delete*: Implementasi *Soft Delete* (mengubah status `IsDeleted` tanpa menghapus baris data).
3.  **Database Seeding:** Inisialisasi data awal untuk kebutuhan pengujian.

## ⚙️ Cara Menjalankan (Lokal)
1.  Pastikan .NET SDK 8.0 dan SQL Server telah terinstal.
2.  Sesuaikan *connection string* pada file `appsettings.json`.
3.  Jalankan migrasi database:
    ```bash
    dotnet ef database update
    ```
4.  Jalankan aplikasi:
    ```bash
    dotnet run
    ```
5.  Akses dokumentasi API melalui: `http://localhost:5273/swagger`

---
**Identitas Pengembang**
* **Nama:** Farrel Athallah Kurniawan
* **NIM:** 3124600089
* **Tugas:** Project-Based Learning (PBL) 2026
