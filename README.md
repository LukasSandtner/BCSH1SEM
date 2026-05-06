## Semestrální práce BCSH1 – Správa financí rodiny

Desktopová aplikace pro evidenci finanční situace rodiny. Umožňuje sledovat příjmy a výdaje jednotlivých členů rodiny a poskytuje přehled o celkovém zůstatku rodinných financí.

---

## Funkce

- Správa členů rodiny – přidání, editace a mazání členů
- Správa kategorií příjmů a výdajů
- Filtrace transakcí
- Přehledová tabulka všech transakcí
- Celkový zůstatek rodinných financí
- Predikce finančního vývoje na příští období
- Grafy výdajů dle kategorií a vývoje v čase

---

## Datový model

Aplikace pracuje se třemi základními entitami:

- **FamilyMember** – jméno, příjmení, role v rodině, datum narození
- **Category** – název, typ (příjem/výdaj), barva (pro budoucí vizualizace)
- **Transaction** – částka, datum, popis, odkaz na člena rodiny a kategorii

---

## Grafy

Aplikace nabízí několik typů grafů (okno **ChartsForm**) pro rychlý přehled o rodinných financích. Pokud nejsou k dispozici žádná data, aplikace zobrazí informační hlášku.

### 1) Koláčový graf: Výdaje podle kategorií
- **Co zobrazuje:** součet **výdajů** seskupený podle **kategorie** (např. Jídlo, Doprava…).
- **Zdroje dat:** transakce typu **"Výdaj"**; kategorie se bere z `Transaction.Cat.Name` (případně **"Neznámá"**).

<img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182200.png" alt="Screenshot 182200" width="600"/><br>


### 2) Koláčový graf: Výdaje podle typu kategorie
- **Co zobrazuje:** součet **výdajů** seskupený podle **typu kategorie** (např. typy/okruhy výdajů).
- **Zdroje dat:** transakce typu **"Výdaj"**; typ se bere z `Transaction.Cat.Type` (případně **"Neznámý typ"**).

<img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182140.png" alt="Screenshot 182140" width="600"/><br>


### 3) Spojnicový graf: Zůstatek v čase
- **Co zobrazuje:** vývoj **kumulativního zůstatku** v čase.
- **Jak se počítá:** zůstatek se průběžně přičítá/odečítá z transakcí: **Příjem = +částka**, **Výdaj = −částka**.

<img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182227.png" alt="Screenshot 182227" width="600"/><br>


### 4) Skládaný sloupcový graf: Příjmy vs. výdaje po měsících
- **Co zobrazuje:** měsíční součty **příjmů** a **výdajů** ve formě skládaných sloupců.
- **Agregace:** seskupení podle **měsíce/roku** (label ve formátu `MM/YYYY`).

<img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182320.png" alt="Screenshot 182320" width="600"/><br>


### 5) Sloupcový graf: Příjmy a výdaje podle členů
- **Co zobrazuje:** součty **příjmů** a **výdajů** pro každého člena rodiny.
- **Zdroje dat:** jméno člena z `Transaction.Member.Name` (případně **"Neznámý"**).

<img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182216.png" alt="Screenshot 182216" width="600"/><br>


### 6) Spojnicový graf: Predikce vývoje zůstatku
- **Co zobrazuje:** odhad budoucího vývoje zůstatku v čase (series **"Predikce"**).
- **Horizont:** volitelně **Týden / Měsíc / Čtvrtletí / Rok** (7 / 30 / 90 / 365 dní).
- **Jak se počítá:** z historie se spočítá **průměrná denní změna** (defaultně z posledních 90 dní, pokud data existují) a ta se lineárně promítne do budoucna.
  
<img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182106.png" alt="Screenshot 182106" width="600"/><br>


## Struktura projektu

```text
FinanceSandtner/
├── Models/
│   ├── FamilyMember.cs
│   ├── Category.cs
│   └── Transaction.cs
├── Services/
│   ├── DatabaseService.cs
│   ├── TransactionService.cs
│   ├── FamilyMemberService.cs
│   └── CategoryService.cs
├── Forms/
│   ├── MainForm.cs
│   ├── TransactionForm.cs
│   ├── MemberForm.cs
│   ├── CategoryForm.cs
│   └── ChartsForm.cs  
├── Program.cs
└── EnumHorizon.cs
```

---

## Ukázky aplikace


<p align="center">
  <p>Hlanví panel aplikace:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20181741.png" alt="Screenshot 181741" width="600"/><br>
  <p>Úprava transakce:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20181830.png" alt="Screenshot 181830" width="600"/><br>
  <p>Vypvoření kategorie:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20181846.png" alt="Screenshot 181846" width="600"/><br>
  <p>Vytvoření člena:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20181906.png" alt="Screenshot 181906" width="600"/><br>
  <p>Vytvoření transakce:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20181953.png" alt="Screenshot 181953" width="600"/><br>
  <p>Odstranění transakce:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182011.png" alt="Screenshot 182011" width="600"/><br>
  <p>Ukončení aplikace:</p>
  <img src="https://github.com/LukasSandtner/BCSH1SEM/raw/main/FinanceSandtner/FinanceSandtner/blob/Sn%C3%ADmek%20obrazovky%202026-05-06%20182029.png" alt="Screenshot 182029" width="600"/><br>
</p>

---

## Technologie

- C# / .NET (Windows Forms)
- Windows Forms
- LiteDB – embedded databáze
- LiveChartsCore.SkiaSharpView
  
---

## Autor

Lukáš Sandtner – školní projekt, 2026/2027
