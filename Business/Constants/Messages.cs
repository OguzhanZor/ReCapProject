using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarIdInvalid = "Araba ıd si gecersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarsListed = "Arabalar listeleniyor";
        public static string CarUpdated = "Araba güncellendi";
        public static string FotoLimited="Fotograflar limitte daha fazla ekleyemezsiniz";
        public static string AuthorizationDenied = "Yetkiniz yok.";
        public static string UserRegistered = "kullanıcı oluşturuldu";
        public static string UserNotFound = "kullanıcı bulunamadı";
        public static string PasswordError = "pasword yanlış";
        public static string SuccessfulLogin = "login işlemi başarılı";
        public static string UserAlreadyExists = "kullanıcı mevcut";
        public static string AccessTokenCreated = "baglantı tokenı olusturuldu";
    }
}
