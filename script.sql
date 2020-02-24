CREATE TABLE FitCardDB.dbo.Categoria (
	Id int IDENTITY(1,1) NOT NULL,
	CategoriaNome nvarchar(40) NOT NULL,
	CategoriaFotoUrl nvarchar(500),
	CreateAt datetime2,
	UpdateAt datetime2,
	PRIMARY KEY (Id)
);

CREATE TABLE FitCardDB.dbo.Empresa (
	Id int IDENTITY(1,1) NOT NULL,
	EmpresaRazao nvarchar(100) NOT NULL,
	EmpresaNomeFantasia nvarchar(100),
	EmpresaCnpj nvarchar(40) NOT NULL,
	EmpresaEmail nvarchar(100),
	EmpresaEndereco nvarchar(150),
	EmpresaCidade nvarchar(50),
	EmpresaEstado nvarchar(40),
	EmpresaTelefone nvarchar(20),
	EmpresaDataCadastro datetime2,
	EmpresaStatus nvarchar(10),
	EmpresaAgencia nvarchar(5),
	EmpresaConta nvarchar(10),
	CategoriaId int NOT NULL,
	CreateAt datetime2,
	UpdateAt datetime2,
	PRIMARY KEY (Id)
);

CREATE TABLE FitCardDB.dbo."User" (
	Id int IDENTITY(1,1) NOT NULL,
	Nome nvarchar(100) NOT NULL,
	Email nvarchar(100) NOT NULL,
	CreateAt datetime2,
	UpdateAt datetime2,
	PRIMARY KEY (Id)
);
CREATE UNIQUE CLUSTERED INDEX PK_Categoria ON dbo.Categoria (Id);

CREATE UNIQUE CLUSTERED INDEX PK_Empresa ON dbo.Empresa (Id);

CREATE UNIQUE CLUSTERED INDEX PK_User ON dbo."User" (Id);



INSERT INTO (CategoriaNome, CreateAt, UpdateAt) VALUES (N'Supermercado', '2020-02-23 02:20:42.3465939', '2020-02-23 02:20:42.3464927');
INSERT INTO (CategoriaNome, CreateAt, UpdateAt) VALUES (N'Restaurante', '2020-02-23 02:20:59.3382122', '0001-01-01 00:00:00.0000000');
INSERT INTO (CategoriaNome, CreateAt, UpdateAt) VALUES (N'Borracharia', '2020-02-23 02:21:10.9743085', '0001-01-01 00:00:00.0000000');
INSERT INTO (CategoriaNome, CreateAt, UpdateAt) VALUES (N'Posto', '2020-02-23 02:21:21.5511132', '0001-01-01 00:00:00.0000000');
INSERT INTO (CategoriaNome, CreateAt, UpdateAt) VALUES (N'Oficina', '2020-02-23 02:21:30.3948018', '0001-01-01 00:00:00.0000000');


