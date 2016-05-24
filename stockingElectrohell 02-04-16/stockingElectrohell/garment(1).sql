-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 24 Mei 2016 pada 12.35
-- Versi Server: 5.6.21
-- PHP Version: 5.6.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `garment`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_color`
--

CREATE TABLE IF NOT EXISTS `tb_color` (
`kode` int(20) NOT NULL,
  `color` varchar(50) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_garment`
--

CREATE TABLE IF NOT EXISTS `tb_garment` (
  `namaGarmen` varchar(100) COLLATE utf8_bin NOT NULL,
  `alamat` varchar(100) COLLATE utf8_bin NOT NULL,
  `tlp` varchar(50) COLLATE utf8_bin NOT NULL,
  `CoPerson` varchar(100) COLLATE utf8_bin NOT NULL,
  `status` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_itemkategori`
--

CREATE TABLE IF NOT EXISTS `tb_itemkategori` (
`kode` int(20) NOT NULL,
  `kategori` varchar(50) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penerimaan`
--

CREATE TABLE IF NOT EXISTS `tb_penerimaan` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `Warehouse` int(5) NOT NULL,
  `nota` varchar(40) COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `garmen` varchar(100) COLLATE utf8_bin NOT NULL,
  `operator` varchar(50) COLLATE utf8_bin NOT NULL,
  `totalQty` int(5) NOT NULL,
  `grandtotal` int(20) NOT NULL,
  `cekStatus` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penerimaandetail`
--

CREATE TABLE IF NOT EXISTS `tb_penerimaandetail` (
  `kode` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL,
  `price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_pengiriman`
--

CREATE TABLE IF NOT EXISTS `tb_pengiriman` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `Warehouse` int(5) NOT NULL,
  `namaToko` varchar(50) COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `operator` varchar(50) COLLATE utf8_bin NOT NULL,
  `totalQty` int(5) NOT NULL,
  `totalJual` int(11) NOT NULL,
  `cekStatus` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_pengirimandetail`
--

CREATE TABLE IF NOT EXISTS `tb_pengirimandetail` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL,
  `disc` int(5) NOT NULL,
  `price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penjualan`
--

CREATE TABLE IF NOT EXISTS `tb_penjualan` (
`auto` int(11) NOT NULL,
  `Warehouse` int(5) NOT NULL,
  `kode` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `nama` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `operator` varchar(50) NOT NULL,
  `totalQty` int(11) NOT NULL,
  `totalJual` int(11) NOT NULL,
  `statJual` varchar(20) NOT NULL,
  `mediaJual` varchar(20) NOT NULL,
  `cekStatus` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penjualandetail`
--

CREATE TABLE IF NOT EXISTS `tb_penjualandetail` (
  `kode` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL,
  `disc` int(5) NOT NULL,
  `price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_produk`
--

CREATE TABLE IF NOT EXISTS `tb_produk` (
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `nama` varchar(50) COLLATE utf8_bin NOT NULL,
  `kategori` varchar(50) COLLATE utf8_bin NOT NULL,
  `hargaPokok` int(15) NOT NULL,
  `hargaJual` int(15) NOT NULL,
  `color` varchar(50) COLLATE utf8_bin NOT NULL,
  `KodeSize` varchar(5) COLLATE utf8_bin NOT NULL,
  `status` varchar(15) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_report`
--

CREATE TABLE IF NOT EXISTS `tb_report` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `status` varchar(20) COLLATE utf8_bin NOT NULL,
  `nama` varchar(50) COLLATE utf8_bin NOT NULL,
  `hargaPokok` int(15) NOT NULL,
  `hargaJual` int(15) NOT NULL,
  `disc` int(15) NOT NULL,
  `total` int(20) NOT NULL,
  `cekStatus` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_return`
--

CREATE TABLE IF NOT EXISTS `tb_return` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `Warehouse` int(5) NOT NULL,
  `tgl` datetime NOT NULL,
  `status` varchar(20) COLLATE utf8_bin NOT NULL,
  `nama` varchar(50) COLLATE utf8_bin NOT NULL,
  `disc` int(5) NOT NULL,
  `operator` varchar(20) COLLATE utf8_bin NOT NULL,
  `totalqty` int(5) NOT NULL,
  `grandtotal` int(20) NOT NULL,
  `cekStatus` int(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_returndetail`
--

CREATE TABLE IF NOT EXISTS `tb_returndetail` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL,
  `disc` int(5) NOT NULL,
  `price` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_size`
--

CREATE TABLE IF NOT EXISTS `tb_size` (
  `Kode` varchar(5) COLLATE utf8_bin NOT NULL,
  `Size` varchar(10) COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `keterangan` varchar(100) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_sponsor`
--

CREATE TABLE IF NOT EXISTS `tb_sponsor` (
  `nama` varchar(50) COLLATE utf8_bin NOT NULL,
  `alamat` varchar(100) COLLATE utf8_bin NOT NULL,
  `tlp` varchar(20) COLLATE utf8_bin NOT NULL,
  `disc` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stokgudang`
--

CREATE TABLE IF NOT EXISTS `tb_stokgudang` (
  `Warehouse` int(5) NOT NULL,
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `qty` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stokgudangdetail`
--

CREATE TABLE IF NOT EXISTS `tb_stokgudangdetail` (
  `Warehouse` int(5) NOT NULL,
  `barcode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `value` int(3) NOT NULL,
  `qty` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stoktoko`
--

CREATE TABLE IF NOT EXISTS `tb_stoktoko` (
  `namaToko` varchar(50) NOT NULL,
  `kodeItem` varchar(50) NOT NULL,
  `qty` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stoktokodetail`
--

CREATE TABLE IF NOT EXISTS `tb_stoktokodetail` (
  `namaToko` varchar(50) NOT NULL,
  `kodeItem` varchar(50) NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stores`
--

CREATE TABLE IF NOT EXISTS `tb_stores` (
  `namaToko` varchar(100) COLLATE utf8_bin NOT NULL,
  `alamat` varchar(100) COLLATE utf8_bin NOT NULL,
  `tlp` varchar(50) COLLATE utf8_bin NOT NULL,
  `CoPerson` varchar(100) COLLATE utf8_bin NOT NULL,
  `disc` int(3) NOT NULL,
  `grade` varchar(2) COLLATE utf8_bin NOT NULL,
  `status` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_subproduk`
--

CREATE TABLE IF NOT EXISTS `tb_subproduk` (
  `barcode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `kodeSize` varchar(10) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_user`
--

CREATE TABLE IF NOT EXISTS `tb_user` (
  `_username` varchar(50) COLLATE utf8_bin NOT NULL,
  `_password` varchar(50) COLLATE utf8_bin NOT NULL,
  `nama` varchar(100) COLLATE utf8_bin NOT NULL,
  `Section` varchar(20) COLLATE utf8_bin NOT NULL,
  `privilege` varchar(20) COLLATE utf8_bin NOT NULL,
  `status` varchar(15) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_usercategory`
--

CREATE TABLE IF NOT EXISTS `tb_usercategory` (
  `Section` varchar(50) COLLATE utf8_bin NOT NULL,
  `privilege` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_warehouse`
--

CREATE TABLE IF NOT EXISTS `tb_warehouse` (
`warehouse` int(11) NOT NULL,
  `warehouseName` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `tb_color`
--
ALTER TABLE `tb_color`
 ADD PRIMARY KEY (`kode`);

--
-- Indexes for table `tb_garment`
--
ALTER TABLE `tb_garment`
 ADD PRIMARY KEY (`namaGarmen`);

--
-- Indexes for table `tb_itemkategori`
--
ALTER TABLE `tb_itemkategori`
 ADD PRIMARY KEY (`kode`);

--
-- Indexes for table `tb_penerimaan`
--
ALTER TABLE `tb_penerimaan`
 ADD PRIMARY KEY (`kode`);

--
-- Indexes for table `tb_pengiriman`
--
ALTER TABLE `tb_pengiriman`
 ADD PRIMARY KEY (`kode`);

--
-- Indexes for table `tb_penjualan`
--
ALTER TABLE `tb_penjualan`
 ADD PRIMARY KEY (`auto`);

--
-- Indexes for table `tb_produk`
--
ALTER TABLE `tb_produk`
 ADD PRIMARY KEY (`kodeItem`);

--
-- Indexes for table `tb_return`
--
ALTER TABLE `tb_return`
 ADD PRIMARY KEY (`kode`);

--
-- Indexes for table `tb_stokgudang`
--
ALTER TABLE `tb_stokgudang`
 ADD PRIMARY KEY (`kodeItem`);

--
-- Indexes for table `tb_stokgudangdetail`
--
ALTER TABLE `tb_stokgudangdetail`
 ADD PRIMARY KEY (`barcode`);

--
-- Indexes for table `tb_stores`
--
ALTER TABLE `tb_stores`
 ADD PRIMARY KEY (`namaToko`);

--
-- Indexes for table `tb_user`
--
ALTER TABLE `tb_user`
 ADD PRIMARY KEY (`_username`), ADD FULLTEXT KEY `_username` (`_username`);

--
-- Indexes for table `tb_usercategory`
--
ALTER TABLE `tb_usercategory`
 ADD PRIMARY KEY (`Section`);

--
-- Indexes for table `tb_warehouse`
--
ALTER TABLE `tb_warehouse`
 ADD PRIMARY KEY (`warehouse`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `tb_color`
--
ALTER TABLE `tb_color`
MODIFY `kode` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=5;
--
-- AUTO_INCREMENT for table `tb_itemkategori`
--
ALTER TABLE `tb_itemkategori`
MODIFY `kode` int(20) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
--
-- AUTO_INCREMENT for table `tb_penjualan`
--
ALTER TABLE `tb_penjualan`
MODIFY `auto` int(11) NOT NULL AUTO_INCREMENT;
--
-- AUTO_INCREMENT for table `tb_warehouse`
--
ALTER TABLE `tb_warehouse`
MODIFY `warehouse` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=2;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
