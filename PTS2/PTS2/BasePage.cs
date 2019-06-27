using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Personeltakip.BLL;
using Personeltakip.VO;
using System.ComponentModel.DataAnnotations;
using System.Xml;

namespace personeltakip.Web
{
    public abstract class BasePage : Page
    {
        private ModelContext _modelContext;

        protected ModelContext ModelContext
        {
            get
            {
                return _modelContext ?? (_modelContext = new ModelContext());
            }
        }
		
				 #region FieldsBolum1
			 private BolumBLL<Bolum> _BolumBLL;
		 #endregion

		 #region FieldsBolum2
		 protected BolumBLL<Bolum> BolumBLL
		 {
			 get
			 {
				 return _BolumBLL = new BolumBLL<Bolum>();
			 }
		 }
		 #endregion

		 #region FieldsIzin1
			 private IzinBLL<Izin> _IzinBLL;
		 #endregion

		 #region FieldsIzin2
		 protected IzinBLL<Izin> IzinBLL
		 {
			 get
			 {
				 return _IzinBLL = new IzinBLL<Izin>();
			 }
		 }
		 #endregion

		 #region FieldsPersonel1
			 private PersonelBLL<Personel> _PersonelBLL;
		 #endregion

		 #region FieldsPersonel2
		 protected PersonelBLL<Personel> PersonelBLL
		 {
			 get
			 {
				 return _PersonelBLL = new PersonelBLL<Personel>();
			 }
		 }
		 #endregion


    }
}