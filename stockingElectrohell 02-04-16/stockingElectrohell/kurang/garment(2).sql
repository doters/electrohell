-- phpMyAdmin SQL Dump
-- version 4.2.11
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 24 Nov 2015 pada 18.57
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
(1, 'putih'),
(2, 'putih gelap'),
(3, 'merah abu'),
(4, 'merah gelap');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_garment`
--

CREATE TABLE IF NOT EXISTS `tb_garment` (
  `namaGarmen` varchar(100) COLLATE utf8_bin NOT NULL,
  `alamat` varchar(100) COLLATE utf8_bin NOT NULL,
  `tlp` varchar(50) COLLATE utf8_bin NOT NULL,
  `CoPerson` varchar(100) COLLATE utf8_bin NOT NULL,
  `disc` int(3) NOT NULL,
  `status` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_garment`
--

INSERT INTO `tb_garment` (`namaGarmen`, `alamat`, `tlp`, `CoPerson`, `disc`, `status`) VALUES
('garmen dua', 'jalan dua', '082', 'dua', 5, 'Aktif'),
('garmen satu', 'jalan satu', '081', 'nama 1', 5, 'Aktif');

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
(1, 'baju putih'),
(2, 'coba'),
(3, 'baju suram'),
(4, 'bajus'),
(5, 'baju putih-kotak polos');

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

--
-- Dumping data untuk tabel `tb_penerimaan`
--

INSERT INTO `tb_penerimaan` (`kode`, `nota`, `tgl`, `garmen`, `operator`, `totalQty`, `grandtotal`) VALUES
('FT112520150001', '123', '2015-11-25 01:25:55', 'garmen dua', 'user1', 16, 80000);

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

--
-- Dumping data untuk tabel `tb_penerimaandetail`
--

INSERT INTO `tb_penerimaandetail` (`kode`, `kodeItem`, `value`, `qty`) VALUES
('FT112520150001', 'kode001', 1, 2),
('FT112520150001', 'kode001', 2, 2),
('FT112520150001', 'kode001', 3, 2),
('FT112520150001', 'kode001', 4, 2),
('FT112520150001', 'kode001', 5, 2),
('FT112520150001', 'kode001', 6, 2),
('FT112520150001', 'kode001', 7, 2),
('FT112520150001', 'kode001', 8, 2);

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

--
-- Dumping data untuk tabel `tb_pengiriman`
--

INSERT INTO `tb_pengiriman` (`kode`, `namaToko`, `tgl`, `operator`, `totalQty`, `totalJual`) VALUES
('FK112520150001', 'aaa', '2015-11-25 01:26:11', 'user1', 16, 152000);

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

--
-- Dumping data untuk tabel `tb_pengirimandetail`
--

INSERT INTO `tb_pengirimandetail` (`kode`, `kodeItem`, `value`, `qty`) VALUES
('FK112520150001', 'kode001', 1, 2),
('FK112520150001', 'kode001', 2, 2),
('FK112520150001', 'kode001', 3, 2),
('FK112520150001', 'kode001', 4, 2),
('FK112520150001', 'kode001', 5, 2),
('FK112520150001', 'kode001', 6, 2),
('FK112520150001', 'kode001', 7, 2),
('FK112520150001', 'kode001', 8, 2);

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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_penjualan`
--

INSERT INTO `tb_penjualan` (`auto`, `kode`, `nama`, `tgl`, `operator`, `totalQty`, `totalJual`, `statJual`, `mediaJual`) VALUES
(2, '-', 'aaa', '2015-11-25 01:26:30', 'user1', 2, 19000, 'Toko', '-'),
(3, '-', 'aaa', '2015-11-25 01:27:13', 'user1', 2, 19000, 'Toko', '-'),
(4, '3', 'aaa', '2015-11-25 01:53:12', 'user1', 1, 9500, 'Toko', '-'),
(5, '4', 'aaa', '2015-11-25 01:54:49', 'user1', 1, 9500, 'Toko', '-');

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

--
-- Dumping data untuk tabel `tb_penjualandetail`
--

INSERT INTO `tb_penjualandetail` (`kode`, `kodeItem`, `value`, `qty`) VALUES
('2015-11-25 01:26:31', 'kode001', 1, 1),
('2015-11-25 01:26:31', 'kode001', 2, 1),
('2015-11-25 01:26:31', 'kode001', 3, 0),
('2015-11-25 01:26:31', 'kode001', 4, 0),
('2015-11-25 01:26:31', 'kode001', 5, 0),
('2015-11-25 01:26:31', 'kode001', 6, 0),
('2015-11-25 01:26:31', 'kode001', 7, 0),
('2015-11-25 01:26:31', 'kode001', 8, 0),
('2015-11-25 01:27:14', 'kode001', 1, 0),
('2015-11-25 01:27:14', 'kode001', 2, 0),
('2015-11-25 01:27:14', 'kode001', 3, 1),
('2015-11-25 01:27:14', 'kode001', 4, 1),
('2015-11-25 01:27:14', 'kode001', 5, 0),
('2015-11-25 01:27:14', 'kode001', 6, 0),
('2015-11-25 01:27:14', 'kode001', 7, 0),
('2015-11-25 01:27:14', 'kode001', 8, 0),
('3', 'kode001', 1, 1),
('3', 'kode001', 2, 0),
('3', 'kode001', 3, 0),
('3', 'kode001', 4, 0),
('3', 'kode001', 5, 0),
('3', 'kode001', 6, 0),
('3', 'kode001', 7, 0),
('3', 'kode001', 8, 0),
('5', 'kode001', 1, 0),
('5', 'kode001', 2, 1),
('5', 'kode001', 3, 0),
('5', 'kode001', 4, 0),
('5', 'kode001', 5, 0),
('5', 'kode001', 6, 0),
('5', 'kode001', 7, 0),
('5', 'kode001', 8, 0);

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
('kode001', 'nama1', 'baju', 5000, 10000, 'putih', 'A', 'Aktif'),
('kode002', 'nama2', 'baju putih-kotak polos', 4000, 15000, 'putih gelap', 'A', 'Aktif');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_size`
--

CREATE TABLE IF NOT EXISTS `tb_size` (
  `Kode` varchar(5) COLLATE utf8_bin NOT NULL,
  `Size` varchar(10) COLLATE utf8_bin NOT NULL,
  `value` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_size`
--

INSERT INTO `tb_size` (`Kode`, `Size`, `value`) VALUES
('A', 'A1', 1),
('A', 'A2', 2),
('A', 'A3', 3),
('A', 'A4', 4),
('A', 'A5', 5),
('A', 'A6', 6),
('A', 'A7', 7),
('A', 'A8', 8);

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
('kode001', 0),
('kode002', 0);

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
('11', 'kode001', 1, 0),
('123', 'kode002', 1, 0),
('22', 'kode001', 2, 0),
('234', 'kode002', 2, 0),
('33', 'kode001', 3, 0),
('345', 'kode002', 3, 0),
('44', 'kode001', 4, 0),
('456', 'kode002', 4, 0),
('55', 'kode001', 5, 0),
('567', 'kode002', 5, 0),
('66', 'kode001', 6, 0),
('678', 'kode002', 6, 0),
('77', 'kode001', 7, 0),
('789', 'kode002', 7, 0),
('88', 'kode001', 8, 0),
('890', 'kode002', 8, 0);

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_stoktoko`
--

CREATE TABLE IF NOT EXISTS `tb_stoktoko` (
  `namaToko` varchar(50) NOT NULL,
  `kodeItem` varchar(50) NOT NULL,
  `qty` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data untuk tabel `tb_stoktoko`
--

INSERT INTO `tb_stoktoko` (`namaToko`, `kodeItem`, `qty`) VALUES
('aaa', 'kode001', 10);

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

--
-- Dumping data untuk tabel `tb_stoktokodetail`
--

INSERT INTO `tb_stoktokodetail` (`namaToko`, `kodeItem`, `value`, `qty`) VALUES
('aaa', 'kode001', 1, 0),
('aaa', 'kode001', 2, 0),
('aaa', 'kode001', 3, 1),
('aaa', 'kode001', 4, 1),
('aaa', 'kode001', 5, 2),
('aaa', 'kode001', 6, 2),
('aaa', 'kode001', 7, 2),
('aaa', 'kode001', 8, 2);

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
('aaa', 'b', '5', 'c', 5, 'A', ''),
('bbb', 'b', '5', 'c', 5, 'B', ''),
('ccc', 'b', '5', 'c', 5, 'C', ''),
('ddd', 'd', 'd', 'd', 5, 'C', 'Aktif');

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
('11', 'kode001', '1'),
('22', 'kode001', '2'),
('33', 'kode001', '3'),
('44', 'kode001', '4'),
('55', 'kode001', '5'),
('66', 'kode001', '6'),
('77', 'kode001', '7'),
('88', 'kode001', '8'),
('123', 'kode002', '1'),
('234', 'kode002', '2'),
('345', 'kode002', '3'),
('456', 'kode002', '4'),
('567', 'kode002', '5'),
('678', 'kode002', '6'),
('789', 'kode002', '7'),
('890', 'kode002', '8');

-- --------------------------------------------------------

--
-- Struktur dari tabel `tb_user`
--

CREATE TABLE IF NOT EXISTS `tb_user` (
  `_username` varchar(50) COLLATE utf8_bin NOT NULL,
  `_password` varchar(50) COLLATE utf8_bin NOT NULL,
  `nama` varchar(100) COLLATE utf8_bin NOT NULL,
  `privilege` varchar(20) COLLATE utf8_bin NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

--
-- Dumping data untuk tabel `tb_user`
--

INSERT INTO `tb_user` (`_username`, `_password`, `nama`, `privilege`) VALUES
('user1', 'user', 'nama user', 'user');

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
 ADD PRIMARY KEY (`_username`);

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
MODIFY `auto` int(11) NOT NULL AUTO_INCREMENT,AUTO_INCREMENT=6;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
