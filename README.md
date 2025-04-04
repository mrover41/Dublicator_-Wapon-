# 🔁 Dublicator Plugin for SCP: Secret Laboratory

**Dublicator** is a custom item plugin for SCP: Secret Laboratory built using the EXILED API. It allows players to duplicate items with customizable rules, restrictions, and in-game messages.

---

## 📦 Features

- ✅ Enable/disable the plugin.
- 🐞 Optional debug mode for logs.
- 📝 Customizable messages for interaction feedback.
- 🚫 Blacklist of items that cannot be duplicated.
- 🧰 Includes a fully configurable **Dublicator** custom item.

---

## ⚙️ Configuration

```csharp
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
```

# 📁 Installation
- Configure the Dublicator.yml or related config file to your preference.

- Restart your server.

# 🧠 Requirements
EXILED >= 5.0.0

SCP: Secret Laboratory (latest compatible version)

# 🛠️ Author
Dublicator was created by Mr_Over41.
Feel free to report issues or contribute via pull requests!



