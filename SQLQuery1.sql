alter table DonHang
	add foreign key (MaSP)
	references SanPham(MaSP);