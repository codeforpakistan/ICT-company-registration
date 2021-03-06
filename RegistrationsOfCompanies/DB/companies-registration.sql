USE [master]
GO
/****** Object:  Database [companies_registration]    Script Date: 2020-12-10 10:07:20 AM ******/
CREATE DATABASE [companies_registration]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'companies_registration', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\companies_registration.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'companies_registration_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\companies_registration_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [companies_registration] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [companies_registration].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [companies_registration] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [companies_registration] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [companies_registration] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [companies_registration] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [companies_registration] SET ARITHABORT OFF 
GO
ALTER DATABASE [companies_registration] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [companies_registration] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [companies_registration] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [companies_registration] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [companies_registration] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [companies_registration] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [companies_registration] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [companies_registration] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [companies_registration] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [companies_registration] SET  ENABLE_BROKER 
GO
ALTER DATABASE [companies_registration] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [companies_registration] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [companies_registration] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [companies_registration] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [companies_registration] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [companies_registration] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [companies_registration] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [companies_registration] SET RECOVERY FULL 
GO
ALTER DATABASE [companies_registration] SET  MULTI_USER 
GO
ALTER DATABASE [companies_registration] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [companies_registration] SET DB_CHAINING OFF 
GO
ALTER DATABASE [companies_registration] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [companies_registration] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [companies_registration] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'companies_registration', N'ON'
GO
USE [companies_registration]
GO
/****** Object:  User [AuthoritySytem]    Script Date: 2020-12-10 10:07:20 AM ******/
CREATE USER [AuthoritySytem] FOR LOGIN [NT AUTHORITY\SYSTEM] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [AuthoritySytem]
GO
ALTER ROLE [db_accessadmin] ADD MEMBER [AuthoritySytem]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [AuthoritySytem]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [AuthoritySytem]
GO
ALTER ROLE [db_backupoperator] ADD MEMBER [AuthoritySytem]
GO
ALTER ROLE [db_datareader] ADD MEMBER [AuthoritySytem]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [AuthoritySytem]
GO
/****** Object:  Table [dbo].[basic_detail]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[basic_detail](
	[basic_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](250) NOT NULL,
	[is_company] [int] NOT NULL,
	[email_address] [varchar](250) NOT NULL,
	[mobile_number] [varchar](250) NOT NULL,
	[phone_number] [varchar](250) NULL,
	[country_id] [int] NOT NULL,
	[province_id] [int] NOT NULL,
	[district_id] [int] NOT NULL,
	[address] [nvarchar](max) NULL,
	[other_details] [nvarchar](max) NULL,
	[cnic] [nvarchar](20) NULL,
 CONSTRAINT [PK_personal_details] PRIMARY KEY CLUSTERED 
(
	[basic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[business_detail]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[business_detail](
	[business_id] [int] IDENTITY(1,1) NOT NULL,
	[basic_id] [int] NOT NULL,
	[principal_country_id] [int] NULL,
	[princiapal_province_id] [int] NULL,
	[principal_distict_id] [int] NULL,
	[business_in_kp_district_id] [int] NOT NULL,
	[city_in_kp] [int] NOT NULL,
	[company_name] [varchar](250) NULL,
	[comapy_website] [varchar](max) NULL,
	[business_email] [varchar](250) NOT NULL,
	[contact_person_name] [varchar](250) NULL,
	[office_number] [varchar](20) NULL,
	[annual_turnover] [decimal](18, 0) NULL,
	[principal_address] [nvarchar](max) NULL,
	[regional_office_address] [nvarchar](max) NULL,
	[operational_since] [date] NULL,
	[registration_with] [nvarchar](150) NULL,
	[registration_with_pseb] [nvarchar](50) NULL,
	[company_short_description] [nvarchar](max) NULL,
	[no_of_employees] [int] NULL,
	[hardware_info] [nvarchar](max) NULL,
	[other_service_detail] [nvarchar](max) NULL,
	[company_logo] [nvarchar](max) NULL,
	[company_Tagline] [nvarchar](150) NULL,
	[is_registered_with_KPITB] [nvarchar](50) NULL,
 CONSTRAINT [PK_business_details] PRIMARY KEY CLUSTERED 
(
	[business_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[cities]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[cities](
	[CityId] [int] IDENTITY(1,1) NOT NULL,
	[CityName] [nvarchar](150) NULL,
	[ProvinceId] [int] NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[CityId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[countries]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[countries](
	[country_id] [int] IDENTITY(1,1) NOT NULL,
	[country_name] [nvarchar](250) NULL,
	[country_code] [varchar](2) NULL,
	[language] [varchar](3) NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[country_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[dev_bpo_area]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[dev_bpo_area](
	[dev_bpo_area_id] [int] IDENTITY(1,1) NOT NULL,
	[basic_ID] [int] NULL,
	[AreaID] [int] NULL,
 CONSTRAINT [PK_dev_bpo_area] PRIMARY KEY CLUSTERED 
(
	[dev_bpo_area_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[district]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[district](
	[district_id] [int] IDENTITY(1,1) NOT NULL,
	[district_name] [nvarchar](250) NULL,
	[province_id] [int] NULL,
 CONSTRAINT [PK_district] PRIMARY KEY CLUSTERED 
(
	[district_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employee_detail]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_detail](
	[employee_id] [int] IDENTITY(1,1) NOT NULL,
	[basic_id] [int] NOT NULL,
	[designation_id] [int] NOT NULL,
	[number_of_resources] [decimal](18, 2) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[employee_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[employee_skills]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee_skills](
	[employee_skills_id] [int] IDENTITY(1,1) NOT NULL,
	[employee_id] [int] NULL,
	[skill_id] [int] NULL,
 CONSTRAINT [PK_employee_skills] PRIMARY KEY CLUSTERED 
(
	[employee_skills_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[position]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[position](
	[position_id] [int] IDENTITY(1,1) NOT NULL,
	[position_title] [nvarchar](250) NULL,
 CONSTRAINT [PK_position] PRIMARY KEY CLUSTERED 
(
	[position_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[province]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[province](
	[province_id] [int] IDENTITY(1,1) NOT NULL,
	[province_name] [nvarchar](250) NULL,
	[country_id] [int] NULL,
 CONSTRAINT [PK_province] PRIMARY KEY CLUSTERED 
(
	[province_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ServicesArea]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ServicesArea](
	[AreaID] [int] IDENTITY(1,1) NOT NULL,
	[AreaType] [varchar](50) NULL,
	[AreaName] [varchar](150) NULL,
 CONSTRAINT [PK_ServicesArea] PRIMARY KEY CLUSTERED 
(
	[AreaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[skills]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[skills](
	[skill_id] [int] IDENTITY(1,1) NOT NULL,
	[skill_name] [varchar](250) NOT NULL,
 CONSTRAINT [PK_skills] PRIMARY KEY CLUSTERED 
(
	[skill_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[system_user]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[system_user](
	[user_id] [int] IDENTITY(1,1) NOT NULL,
	[role_id] [int] NOT NULL,
	[email_id] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[is_active] [int] NULL,
	[other_detail] [varchar](50) NULL,
 CONSTRAINT [PK_system_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user_role]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user_role](
	[role_id] [int] IDENTITY(1,1) NOT NULL,
	[role_title] [varchar](50) NOT NULL,
	[role_details] [varchar](500) NULL,
 CONSTRAINT [PK_user_role] PRIMARY KEY CLUSTERED 
(
	[role_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[basic_detail]  WITH CHECK ADD  CONSTRAINT [FK_basic_detail_country] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([country_id])
GO
ALTER TABLE [dbo].[basic_detail] CHECK CONSTRAINT [FK_basic_detail_country]
GO
ALTER TABLE [dbo].[basic_detail]  WITH CHECK ADD  CONSTRAINT [FK_basic_detail_district] FOREIGN KEY([district_id])
REFERENCES [dbo].[district] ([district_id])
GO
ALTER TABLE [dbo].[basic_detail] CHECK CONSTRAINT [FK_basic_detail_district]
GO
ALTER TABLE [dbo].[basic_detail]  WITH CHECK ADD  CONSTRAINT [FK_basic_detail_province] FOREIGN KEY([province_id])
REFERENCES [dbo].[province] ([province_id])
GO
ALTER TABLE [dbo].[basic_detail] CHECK CONSTRAINT [FK_basic_detail_province]
GO
ALTER TABLE [dbo].[business_detail]  WITH CHECK ADD  CONSTRAINT [FK_business_detail_basic_detail] FOREIGN KEY([basic_id])
REFERENCES [dbo].[basic_detail] ([basic_id])
GO
ALTER TABLE [dbo].[business_detail] CHECK CONSTRAINT [FK_business_detail_basic_detail]
GO
ALTER TABLE [dbo].[business_detail]  WITH CHECK ADD  CONSTRAINT [FK_business_detail_Cities] FOREIGN KEY([city_in_kp])
REFERENCES [dbo].[cities] ([CityId])
GO
ALTER TABLE [dbo].[business_detail] CHECK CONSTRAINT [FK_business_detail_Cities]
GO
ALTER TABLE [dbo].[business_detail]  WITH CHECK ADD  CONSTRAINT [FK_business_detail_country] FOREIGN KEY([principal_country_id])
REFERENCES [dbo].[countries] ([country_id])
GO
ALTER TABLE [dbo].[business_detail] CHECK CONSTRAINT [FK_business_detail_country]
GO
ALTER TABLE [dbo].[business_detail]  WITH CHECK ADD  CONSTRAINT [FK_business_detail_district] FOREIGN KEY([principal_distict_id])
REFERENCES [dbo].[district] ([district_id])
GO
ALTER TABLE [dbo].[business_detail] CHECK CONSTRAINT [FK_business_detail_district]
GO
ALTER TABLE [dbo].[business_detail]  WITH CHECK ADD  CONSTRAINT [FK_business_detail_province] FOREIGN KEY([princiapal_province_id])
REFERENCES [dbo].[province] ([province_id])
GO
ALTER TABLE [dbo].[business_detail] CHECK CONSTRAINT [FK_business_detail_province]
GO
ALTER TABLE [dbo].[dev_bpo_area]  WITH CHECK ADD  CONSTRAINT [FK_dev_bpo_area_basic_detail] FOREIGN KEY([basic_ID])
REFERENCES [dbo].[basic_detail] ([basic_id])
GO
ALTER TABLE [dbo].[dev_bpo_area] CHECK CONSTRAINT [FK_dev_bpo_area_basic_detail]
GO
ALTER TABLE [dbo].[district]  WITH CHECK ADD  CONSTRAINT [FK_district_province] FOREIGN KEY([province_id])
REFERENCES [dbo].[province] ([province_id])
GO
ALTER TABLE [dbo].[district] CHECK CONSTRAINT [FK_district_province]
GO
ALTER TABLE [dbo].[employee_detail]  WITH CHECK ADD  CONSTRAINT [FK_Employee_basic_detail] FOREIGN KEY([basic_id])
REFERENCES [dbo].[basic_detail] ([basic_id])
GO
ALTER TABLE [dbo].[employee_detail] CHECK CONSTRAINT [FK_Employee_basic_detail]
GO
ALTER TABLE [dbo].[employee_detail]  WITH CHECK ADD  CONSTRAINT [FK_Employee_position] FOREIGN KEY([designation_id])
REFERENCES [dbo].[position] ([position_id])
GO
ALTER TABLE [dbo].[employee_detail] CHECK CONSTRAINT [FK_Employee_position]
GO
ALTER TABLE [dbo].[employee_skills]  WITH CHECK ADD  CONSTRAINT [FK_employee_skills_Employee] FOREIGN KEY([employee_id])
REFERENCES [dbo].[employee_detail] ([employee_id])
GO
ALTER TABLE [dbo].[employee_skills] CHECK CONSTRAINT [FK_employee_skills_Employee]
GO
ALTER TABLE [dbo].[employee_skills]  WITH CHECK ADD  CONSTRAINT [FK_employee_skills_skills] FOREIGN KEY([skill_id])
REFERENCES [dbo].[skills] ([skill_id])
GO
ALTER TABLE [dbo].[employee_skills] CHECK CONSTRAINT [FK_employee_skills_skills]
GO
ALTER TABLE [dbo].[province]  WITH CHECK ADD  CONSTRAINT [FK_province_country] FOREIGN KEY([country_id])
REFERENCES [dbo].[countries] ([country_id])
GO
ALTER TABLE [dbo].[province] CHECK CONSTRAINT [FK_province_country]
GO
ALTER TABLE [dbo].[system_user]  WITH CHECK ADD  CONSTRAINT [FK_system_user_user_role] FOREIGN KEY([role_id])
REFERENCES [dbo].[user_role] ([role_id])
GO
ALTER TABLE [dbo].[system_user] CHECK CONSTRAINT [FK_system_user_user_role]
GO
/****** Object:  StoredProcedure [dbo].[sp_district_wise_company_names]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_district_wise_company_names]
as 
begin


select d.district_name as district, bd.company_name as CompanyName
from business_detail bd join district d on bd.principal_distict_id = d.district_id
group by d.district_name, bd.company_name

end




GO
/****** Object:  StoredProcedure [dbo].[sp_district_wise_freelancers_and_companies]    Script Date: 2020-12-10 10:07:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[sp_district_wise_freelancers_and_companies]
as 
begin


SELECT
         d.district_name district,
         COUNT(distinct f.basic_id) AS freelancers,
         COUNT(distinct c.business_id) AS companies
    FROM
         district d
          JOIN basic_detail f ON f.district_id = d.district_id
          JOIN business_detail c ON c.principal_distict_id = d.district_id
    GROUP BY
         d.district_name;

end



--select dist.district_name, COUNT(basd.basic_id) as freelancer
--from basic_detail basd join district dist on basd.district_id=dist.district_id group by dist.district_name

--select d.district_name as district, 
--COUNT(bd.principal_distict_id) as companies
--from business_detail bd join district d on bd.principal_distict_id = d.district_id
--group by d.district_name
GO
USE [master]
GO
ALTER DATABASE [companies_registration] SET  READ_WRITE 
GO
