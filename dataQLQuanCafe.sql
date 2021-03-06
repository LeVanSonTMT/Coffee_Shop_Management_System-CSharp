		
		create database DataQLQuanCafe;
		go 
		use DataQLQuanCafe;
		 
		--Bảng tài khoản
		create table account
		(	
			username nvarchar(100) not null primary key,
			passwork nvarchar(1000) not null,
			tendK nvarchar(100) not null,
			loai int not null,
			id int identity
		);
		
		--Bảng món ăn
		create table food(
			idfood  int identity primary key,
			tenFood nvarchar(100),
			giafood int
		);
		
		--Bảng bàn ăn
		create table ban(
			idban int identity primary key,
			tenban nvarchar(100),
			ttban nvarchar(20)
		);	
			
		--Bảng hóa đơn
		create table hoadon(
			idhd  int identity primary key,
			thoigianvao date not null,
			thoigianra date,
			idban int,
			tongtien int,
			tthd nvarchar(20) not null
			Foreign key (idban) references dbo.ban(idban) on delete set null	);	
		
		--Bảng chi tiết hóa đơn 
		create table chitiethoadon(
			id  int identity primary key,
			idhd int not null,
			idfood int,
			soluong int not null,

			Foreign key (idhd) references dbo.hoadon(idhd),
			Foreign key (idfood) references dbo.Food(idfood) on delete set null
		);		
		
		go
		create PROC USP_GetAccountUserName
		@username nvarchar(100)
		as
		begin
			select * from account where username = @username;
		end
		go
		
		-- lay tai khoan
		create PROC USP_Login
		@username nvarchar(100), @pass nvarchar(100)
		as
		begin
			select * from account where username = @username and passwork = @pass;
		end
		go
		
		-- lay dl ban an
		create PROC USP_GetBanAn
		as Select * from ban 
		go
		
		-- chen dl vao hoa don
		create PROC USP_InsertBill
		@idban int
		as
		begin
			insert hoadon values(GETDATE(), null, @idban,null, 'chua thanh toan')
		end
		go
		
		-- chen dl vo chi tiet hoa don
		create PROCEDURE USP_InsertChiTietHoaDon
		@idhd int, @idfood int, @soluong int
		AS
		BEGIN
			declare @isExitBillInfo int
			declare @soluongFood int = 1
			select @isExitBillInfo = id, @soluongFood = soluong 
				from chitiethoadon where idhd=@idhd and idfood=@idfood
			if(@isExitBillInfo > 0)
				begin
					declare @newSoLuong int = @soluongFood + @soluong
					if(@newSoLuong > 0)
						update chitiethoadon set soluong = @soluongFood + @soluong where idfood = @idfood
					else
						delete chitiethoadon where idhd=@idhd and idfood=@idfood
				end			
			else
				begin			
					insert chitiethoadon(idhd, idfood, soluong) values(@idhd, @idfood, @soluong)
				end
		END
		go
		
		--cap nhat chi tiet hoa don
		create trigger UTG_UpdateChiTietHoaDon
		ON chitiethoadon for insert, update
		AS
		BEGIN
			Declare @idhd int 
			select @idhd = idhd from inserted
			
			Declare @idban int
			Select @idban = idban from hoadon where idhd = @idhd and tthd='chua thanh toan'
			
			declare @count int
			select @count=COUNT(*) from chitiethoadon where idhd=@idhd
			if(@count>0)
				update ban set ttban = 'Co nguoi' where idban = @idban
			else
				update ban set ttban = 'Trong' where idban = @idban
		END
		go
		
		-- cap nhat hoa don
		create trigger UTG_UpdateHoaDon
		ON hoadon for update
		AS
		begin
			declare @idhd int
			select @idhd=idhd from inserted
			declare @idban int
			Select @idban = idban from hoadon where idhd = @idhd
			declare @count int =0
			Select @count = COUNT(*) from hoadon where idhd = @idhd and tthd='chua thanh toan'
			if(@count = 0)
				update ban set ttban = 'Trong' where idban = @idban	
		end
		go
		
		-- chuyen ban
		create PROC USP_ChuyenBan
		@idBan1 int, @idBan2 int
		AS
		BEGIN
			Declare @idfirstBill int
			Declare @idSecondBill int
			Declare @tam1 int=1
			Declare @tam2 int=1
			
			Select @idSecondBill = idhd from hoadon where idban=@idBan2 and tthd='chua thanh toan'
			Select @idfirstBill = idhd from hoadon where idban=@idBan1 and tthd='chua thanh toan'
			
			if(@idfirstBill is null)
				begin
					insert hoadon(thoigianvao,thoigianra,idban,tthd) values(GETDATE(), null, @idBan1, 'chua thanh toan' )
					Select @idfirstBill = MAX(idhd) from hoadon where idban=@idBan1 and tthd='chua thanh toan'
				end
			select @tam1=COUNT(*) from chitiethoadon where idhd=@idfirstBill
			if(@idSecondBill is null)
				begin
					insert hoadon(thoigianvao,thoigianra,idban,tthd) values(GETDATE(), null, @idBan2, 'chua thanh toan' )
					Select @idSecondBill = MAX(idhd) from hoadon where idban=@idBan2 and tthd='chua thanh toan'
				end
			select @tam2=COUNT(*) from chitiethoadon where idhd=@idSecondBill
			
			SELECT id into IDBillInfo from chitiethoadon where idhd=@idSecondBill
			
			update chitiethoadon set idhd=@idSecondBill where idhd=@idfirstBill
			update chitiethoadon set idhd=@idfirstBill where id in (select * from IDBillInfo)
			
			drop table IDBillInfo
			
			if(@tam1 = 0)
				update ban set ttban='Trong' where idban=@idBan2
			if(@tam2 = 0)
				update ban set ttban='Trong' where idban=@idBan1
		END
		go
		
		--lay doanh thu cua ban an qua thoi gian
		create PROC USP_GETListBillByDate
		@tgvao date, @tgra date
		AS
		begin
			select DISTINCT b.tenban as [Ten ban], h.tongtien as [Tong tien], h.thoigianvao as [Thoi gian vao], h.thoigianra as [Thoi gian ra] 
			From hoadon as h, food as f, ban as b, chitiethoadon as c
			where h.idhd=c.idhd and c.idfood=f.idfood and h.idban=b.idban and h.tthd='da thanh toan'
			and thoigianvao>=@tgvao and thoigianra<=@tgra
		end
		go
		
		--Cap nhat Tai Khoan
		create PROC USP_UpdateAccount
		@id int, @tenDK nvarchar(100), @username nvarchar(100), @pass nvarchar(100), @newpass nvarchar(100)
		AS
		BEGIN
			Declare @isKTpass int =0
			Select @isKTpass=COUNT(*) From account where id=@id
			if(@isKTpass = 1)
			begin
				if(@newpass=NULL or @newpass='' )
					update account set tendK=@tenDK, username=@username where id=@id
				else
					update account set tendK=@tenDK, passwork=@newpass, username=@username where id=@id
			end
		END
		GO
		
		
		
	--them ban an
		insert into ban values('Ban 01','Trong');
		insert into ban values('Ban 02','Trong');
		insert into ban values('Ban 03','Trong');
		insert into ban values('Ban 04','Trong');
		insert into ban values('Ban 05','Trong');
		insert into ban values('Ban 06','Trong');
		insert into ban values('Ban 07','Trong');
		insert into ban values('Ban 08','Trong');
		insert into ban values('Ban 09','Trong');
		insert into ban values('Ban 10','Trong');
		insert into ban values('Ban 11','Trong');
		insert into ban values('Ban 12','Trong');
		insert into ban values('Ban 13','Trong');
		insert into ban values('Ban 14','Trong');
		insert into ban values('Ban 15','Trong');
		insert into ban values('Ban 16','Trong');
		insert into ban values('Ban 17','Trong');
		insert into ban values('Ban 18','Trong');
		insert into ban values('Ban 19','Trong');
		insert into ban values('Ban 20','Trong');
		
	-- them tai khoan
		insert into account values('lvson','lvson','Le Van Son',1);
		insert into account values('User1','user1','Cao Thang',2);
		insert into account values('User2','user2','Doan Binh',2);
		insert into account values('User3','user3','Tran Ngan',2);
		
		
	--them mon an
		insert into Food values('CaFe sua',15000)
		insert into Food values('CaFe da',12000)
		insert into Food values('CaFe nong',20000)
		insert into Food values('Tra duong',10000)
		insert into Food values('Sting',18000)
		insert into Food values('CaCao nong',20000)
		insert into Food values('CaCao sua',20000)
		
		
		