﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace P02Biblioteka
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="ZawodnicyDB")]
	public partial class ModelBazyDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertZawodnik(Zawodnik instance);
    partial void UpdateZawodnik(Zawodnik instance);
    partial void DeleteZawodnik(Zawodnik instance);
    #endregion
		
		public ModelBazyDataContext() : 
				base(global::P02Biblioteka.Properties.Settings.Default.ZawodnicyDBConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public ModelBazyDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelBazyDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelBazyDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public ModelBazyDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Zawodnik> Zawodnik
		{
			get
			{
				return this.GetTable<Zawodnik>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Zawodnicy")]
	public partial class Zawodnik : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id_zawodnika;
		
		private System.Nullable<int> _id_trenera;
		
		private string _imie;
		
		private string _nazwisko;
		
		private string _kraj;
		
		private System.Nullable<System.DateTime> _data_ur;
		
		private System.Nullable<int> _wzrost;
		
		private System.Nullable<int> _waga;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_zawodnikaChanging(int value);
    partial void OnId_zawodnikaChanged();
    partial void OnId_treneraChanging(System.Nullable<int> value);
    partial void OnId_treneraChanged();
    partial void OnImieChanging(string value);
    partial void OnImieChanged();
    partial void OnNazwiskoChanging(string value);
    partial void OnNazwiskoChanged();
    partial void OnKrajChanging(string value);
    partial void OnKrajChanged();
    partial void OnDataUrodzeniaChanging(System.Nullable<System.DateTime> value);
    partial void OnDataUrodzeniaChanged();
    partial void OnWzrostChanging(System.Nullable<int> value);
    partial void OnWzrostChanged();
    partial void OnWagaChanging(System.Nullable<int> value);
    partial void OnWagaChanged();
    #endregion
		
		public Zawodnik()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="id_zawodnika", Storage="_id_zawodnika", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id_zawodnika
		{
			get
			{
				return this._id_zawodnika;
			}
			set
			{
				if ((this._id_zawodnika != value))
				{
					this.OnId_zawodnikaChanging(value);
					this.SendPropertyChanging();
					this._id_zawodnika = value;
					this.SendPropertyChanged("Id_zawodnika");
					this.OnId_zawodnikaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="id_trenera", Storage="_id_trenera", DbType="Int")]
		public System.Nullable<int> Id_trenera
		{
			get
			{
				return this._id_trenera;
			}
			set
			{
				if ((this._id_trenera != value))
				{
					this.OnId_treneraChanging(value);
					this.SendPropertyChanging();
					this._id_trenera = value;
					this.SendPropertyChanged("Id_trenera");
					this.OnId_treneraChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="imie", Storage="_imie", DbType="VarChar(255)")]
		public string Imie
		{
			get
			{
				return this._imie;
			}
			set
			{
				if ((this._imie != value))
				{
					this.OnImieChanging(value);
					this.SendPropertyChanging();
					this._imie = value;
					this.SendPropertyChanged("Imie");
					this.OnImieChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="nazwisko", Storage="_nazwisko", DbType="VarChar(255)")]
		public string Nazwisko
		{
			get
			{
				return this._nazwisko;
			}
			set
			{
				if ((this._nazwisko != value))
				{
					this.OnNazwiskoChanging(value);
					this.SendPropertyChanging();
					this._nazwisko = value;
					this.SendPropertyChanged("Nazwisko");
					this.OnNazwiskoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="kraj", Storage="_kraj", DbType="VarChar(255)")]
		public string Kraj
		{
			get
			{
				return this._kraj;
			}
			set
			{
				if ((this._kraj != value))
				{
					this.OnKrajChanging(value);
					this.SendPropertyChanging();
					this._kraj = value;
					this.SendPropertyChanged("Kraj");
					this.OnKrajChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="data_ur", Storage="_data_ur", DbType="DateTime")]
		public System.Nullable<System.DateTime> DataUrodzenia
		{
			get
			{
				return this._data_ur;
			}
			set
			{
				if ((this._data_ur != value))
				{
					this.OnDataUrodzeniaChanging(value);
					this.SendPropertyChanging();
					this._data_ur = value;
					this.SendPropertyChanged("DataUrodzenia");
					this.OnDataUrodzeniaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="wzrost", Storage="_wzrost", DbType="Int")]
		public System.Nullable<int> Wzrost
		{
			get
			{
				return this._wzrost;
			}
			set
			{
				if ((this._wzrost != value))
				{
					this.OnWzrostChanging(value);
					this.SendPropertyChanging();
					this._wzrost = value;
					this.SendPropertyChanged("Wzrost");
					this.OnWzrostChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="waga", Storage="_waga", DbType="Int")]
		public System.Nullable<int> Waga
		{
			get
			{
				return this._waga;
			}
			set
			{
				if ((this._waga != value))
				{
					this.OnWagaChanging(value);
					this.SendPropertyChanging();
					this._waga = value;
					this.SendPropertyChanged("Waga");
					this.OnWagaChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
