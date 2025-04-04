using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Dublicator.Config {
    internal class Config : IConfig {
        [Description("Settings")]
        public bool IsEnabled { get; set; }
        public bool Debug { get; set; }
        public string Select_information { get; set; } = "<b><color=#FCF7D9>Ви підібрали</color> <color=#00ADAD>Дублікатор</color></b>";
        public string Dead_information { get; set; }  = "Душа покинула его убегая от парадоксов";
        public string Error_information { get; set; } = "<color=#FF5E3F> Ви не можете дублювати цей предмет </color>";
        public List<ItemType> Black_list { get; set; } = new List<ItemType> { 
            ItemType.MicroHID,
        };

        [Description("CustomItem")]
        public Dublicator.Items.Dublicator item = new Dublicator.Items.Dublicator();
    }
}
