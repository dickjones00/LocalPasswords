﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Security.Credentials;

namespace LocalPasswordsLib.BLL
{
    public class CredentialBLL
    {
        public const String Resource = "LocalPasswords";
        public const String Username = "Username";

        public CredentialBLL()
        {

        }

        public Boolean CheckIfExists()
        {
            var vault = new PasswordVault();
            return vault.FindAllByResource(Resource).ToList().Count > 0;
        }

        public String RetrivePassword()
        {
            var vault = new PasswordVault();
            var cred = vault.FindAllByResource(Resource).FirstOrDefault();

            return cred.Password;
        }

        public void SavePassword(String Password)
        {
            var vault = new PasswordVault();
            var cred = new PasswordCredential(Resource, Username, Password);

            var passList = vault.FindAllByResource(Resource).ToList();

            foreach (var item in passList)
            {
                vault.Remove(item);
            }

            vault.Add(cred);
        }
    }
}
