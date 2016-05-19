-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 14 Des 2015 pada 15.41
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

--
-- Dumping data untuk tabel `tb_color`
--

INSERT INTO `tb_color` (`kode`, `color`) VALUES
(1, 'war1'),
(2, 'war2'),
(3, 'war3'),
(4, 'war4');

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

--
-- Dumping data untuk tabel `tb_garment`
--

INSERT INTO `tb_garment` (`namaGarmen`, `alamat`, `tlp`, `CoPerson`, `status`) VALUES
('garmen1', 'alamat', '2342342', 'person', 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_itemkategori`
--

CREATE TABLE IF NOT EXISTS `tb_itemkategori` (
`kode` int(20) NOT NULL,
  `kategori` varchar(50) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_itemkategori`
--

INSERT INTO `tb_itemkategori` (`kode`, `kategori`) VALUES
(1, 'kat1'),
(2, 'gg'),
(3, 'kat 2'),
(4, 'kat3'),
(5, 'kat4');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penerimaan`
--

CREATE TABLE IF NOT EXISTS `tb_penerimaan` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `nota` varchar(40) COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `garmen` varchar(100) COLLATE utf8_bin NOT NULL,
  `operator` varchar(50) COLLATE utf8_bin NOT NULL,
  `totalQty` int(5) NOT NULL,
  `grandtotal` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penerimaandetail`
--

CREATE TABLE IF NOT EXISTS `tb_penerimaandetail` (
  `kode` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_pengiriman`
--

CREATE TABLE IF NOT EXISTS `tb_pengiriman` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `namaToko` varchar(50) COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `operator` varchar(50) COLLATE utf8_bin NOT NULL,
  `totalQty` int(5) NOT NULL,
  `totalJual` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_pengirimandetail`
--

CREATE TABLE IF NOT EXISTS `tb_pengirimandetail` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penjualan`
--

CREATE TABLE IF NOT EXISTS `tb_penjualan` (
`auto` int(11) NOT NULL,
  `kode` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `nama` varchar(50) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `operator` varchar(50) NOT NULL,
  `totalQty` int(11) NOT NULL,
  `totalJual` int(11) NOT NULL,
  `statJual` varchar(20) NOT NULL,
  `mediaJual` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_penjualandetail`
--

CREATE TABLE IF NOT EXISTS `tb_penjualandetail` (
  `kode` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) CHARACTER SET utf8 COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL
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

--
-- Dumping data untuk tabel `tb_produk`
--

INSERT INTO `tb_produk` (`kodeItem`, `nama`, `kategori`, `hargaPokok`, `hargaJual`, `color`, `KodeSize`, `status`) VALUES
('kode01', 'produk1', 'kat1', 5000, 10000, 'war1', 'A', 'Aktif'),
('kode02', 'nama 2', 'kat 2', 500, 5000, 'war2', 'C', 'Aktif'),
('kode03', 'nama3', 'kat3', 5000, 6000, 'war3', 'B', 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_report`
--

CREATE TABLE IF NOT EXISTS `tb_report` (
  `kodeItem` varchar(20) NOT NULL,
  `nama` varchar(50) NOT NULL,
  `Color` varchar(20) NOT NULL,
  `Kode` varchar(5) NOT NULL,
  `S1` varchar(10) NOT NULL,
  `S2` varchar(10) NOT NULL,
  `S3` varchar(10) NOT NULL,
  `S4` varchar(10) NOT NULL,
  `S5` varchar(10) NOT NULL,
  `S6` varchar(10) NOT NULL,
  `S7` varchar(10) NOT NULL,
  `S8` varchar(10) NOT NULL,
  `totQty` int(5) NOT NULL,
  `price1` int(5) NOT NULL,
  `cons` int(5) NOT NULL,
  `price2` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_return`
--

CREATE TABLE IF NOT EXISTS `tb_return` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `tgl` datetime NOT NULL,
  `status` varchar(20) COLLATE utf8_bin NOT NULL,
  `nama` varchar(50) COLLATE utf8_bin NOT NULL,
  `disc` int(5) NOT NULL,
  `operator` varchar(20) COLLATE utf8_bin NOT NULL,
  `totalqty` int(5) NOT NULL,
  `grandtotal` int(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_returndetail`
--

CREATE TABLE IF NOT EXISTS `tb_returndetail` (
  `kode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(20) COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL,
  `qty` int(5) NOT NULL
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

--
-- Dumping data untuk tabel `tb_size`
--

INSERT INTO `tb_size` (`Kode`, `Size`, `value`, `keterangan`) VALUES
('A', 'A1`', 1, 'SIZE A'),
('A', 'A2', 2, 'SIZE A'),
('A', 'A3', 3, 'SIZE A'),
('A', 'A4', 4, 'SIZE A'),
('A', 'A5', 5, 'SIZE A'),
('A', 'A6', 6, 'SIZE A'),
('A', 'A7', 7, 'SIZE A'),
('A', 'A8', 8, 'SIZE A'),
('B', 'B1', 1, 'SIZE B'),
('B', 'B2', 2, 'SIZE B'),
('B', 'B3', 3, 'SIZE B'),
('B', 'B4', 4, 'SIZE B'),
('B', 'B5', 5, 'SIZE B'),
('B', 'B6', 6, 'SIZE B'),
('B', 'B7', 7, 'SIZE B'),
('B', 'B8', 8, 'SIZE B'),
('C', 'C1', 1, 'Size C'),
('C', 'C2', 2, 'Size C'),
('C', 'C3', 3, 'Size C'),
('C', 'C4', 4, 'Size C'),
('C', 'C5', 5, 'Size C'),
('C', 'C6', 6, 'Size C'),
('C', 'C7', 7, 'Size C'),
('C', 'C8', 8, 'Size C'),
('D', 'D1', 1, 'size D'),
('D', 'D2', 2, 'size D'),
('D', 'D3', 3, 'size D'),
('D', 'D4', 4, 'size D'),
('D', 'D5', 5, 'size D'),
('D', 'D6', 6, 'size D'),
('D', 'D7', 7, 'size D'),
('D', 'D8', 8, 'size D');

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

--
-- Dumping data untuk tabel `tb_sponsor`
--

INSERT INTO `tb_sponsor` (`nama`, `alamat`, `tlp`, `disc`) VALUES
('sponsor1', 'jalan 1', '081', 100),
('sponsor1', 'jalan 1', '081', 100);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stokgudang`
--

CREATE TABLE IF NOT EXISTS `tb_stokgudang` (
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `qty` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_stokgudang`
--

INSERT INTO `tb_stokgudang` (`kodeItem`, `qty`) VALUES
('kode01', 0),
('kode02', 0),
('kode03', 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stokgudangdetail`
--

CREATE TABLE IF NOT EXISTS `tb_stokgudangdetail` (
  `barcode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `value` int(3) NOT NULL,
  `qty` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_stokgudangdetail`
--

INSERT INTO `tb_stokgudangdetail` (`barcode`, `kodeItem`, `value`, `qty`) VALUES
('098', 'kode03', 1, 0),
('11', 'kode01', 1, 0),
('123', 'kode02', 1, 0),
('22', 'kode01', 2, 0),
('234', 'kode02', 2, 0),
('321', 'kode03', 8, 0),
('33', 'kode01', 3, 0),
('345', 'kode02', 3, 0),
('432', 'kode03', 7, 0),
('44', 'kode01', 4, 0),
('456', 'kode02', 4, 0),
('543', 'kode03', 6, 0),
('55', 'kode01', 5, 0),
('567', 'kode02', 5, 0),
('654', 'kode03', 5, 0),
('66', 'kode01', 6, 0),
('678', 'kode02', 6, 0),
('765', 'kode03', 4, 0),
('77', 'kode01', 7, 0),
('789', 'kode02', 7, 0),
('876', 'kode03', 3, 0),
('88', 'kode01', 8, 0),
('890', 'kode02', 8, 0),
('987', 'kode03', 2, 0);

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

--
-- Dumping data untuk tabel `tb_stores`
--

INSERT INTO `tb_stores` (`namaToko`, `alamat`, `tlp`, `CoPerson`, `disc`, `grade`, `status`) VALUES
('store 1', 'alamat', '90809', 'person', 20, 'A', 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_subproduk`
--

CREATE TABLE IF NOT EXISTS `tb_subproduk` (
  `barcode` varchar(20) COLLATE utf8_bin NOT NULL,
  `kodeItem` varchar(50) COLLATE utf8_bin NOT NULL,
  `kodeSize` varchar(10) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_subproduk`
--

INSERT INTO `tb_subproduk` (`barcode`, `kodeItem`, `kodeSize`) VALUES
('11', 'kode01', '1'),
('22', 'kode01', '2'),
('33', 'kode01', '3'),
('44', 'kode01', '4'),
('55', 'kode01', '5'),
('66', 'kode01', '6'),
('77', 'kode01', '7'),
('88', 'kode01', '8'),
('123', 'kode02', '1'),
('234', 'kode02', '2'),
('345', 'kode02', '3'),
('456', 'kode02', '4'),
('567', 'kode02', '5'),
('678', 'kode02', '6'),
('789', 'kode02', '7'),
('890', 'kode02', '8'),
('098', 'kode03', '1'),
('987', 'kode03', '2'),
('876', 'kode03', '3'),
('765', 'kode03', '4'),
('654', 'kode03', '5'),
('543', 'kode03', '6'),
('432', 'kode03', '7'),
('321', 'kode03', '8');

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

--
-- Dumping data untuk tabel `tb_user`
--

INSERT INTO `tb_user` (`_username`, `_password`, `nama`, `Section`, `privilege`, `status`) VALUES
('Admin', 'Admin', 'Admin', '', 'Admin', ''),
('user1', 'user', 'nama user', 'Accounting', 'User', 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_usercategory`
--

CREATE TABLE IF NOT EXISTS `tb_usercategory` (
  `Section` varchar(50) COLLATE utf8_bin NOT NULL,
  `privilege` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_usercategory`
--

INSERT INTO `tb_usercategory` (`Section`, `privilege`) VALUES
('Acc', 'Admin'),
('Accounting', 'Admin');

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
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
