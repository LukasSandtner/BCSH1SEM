## Semestrální práce BCSH1 – Správa financí rodiny

Desktopová aplikace pro evidenci finanční situace rodiny. Umožňuje sledovat příjmy a výdaje jednotlivých členů rodiny a poskytuje přehled o celkovém zůstatku rodinných financí.

> - **TODO** Test LiteDB objektů.

---

## Funkce

- Správa členů rodiny – přidání, editace a mazání členů
- Správa kategorií příjmů a výdajů
- Evidence transakcí s přiřazením členu rodiny a kategorii
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

Aplikace nabízí několik typů grafů (okno **ChartsForm**) pro rychlý přehled o rodinných financích. Pokud nejsou k dispozici žádná data (nebo žádné výdaje/příjmy pro daný typ grafu), aplikace zobrazí informační hlášku.

### 1) Koláčový graf: Výdaje podle kategorií
- **Co zobrazuje:** součet **výdajů** seskupený podle **kategorie** (např. Jídlo, Doprava…).
- **Zdroje dat:** transakce typu **"Výdaj"**; kategorie se bere z `Transaction.Cat.Name` (případně **"Neznámá"**).

### 2) Koláčový graf: Výdaje podle typu kategorie
- **Co zobrazuje:** součet **výdajů** seskupený podle **typu kategorie** (např. typy/okruhy výdajů).
- **Zdroje dat:** transakce typu **"Výdaj"**; typ se bere z `Transaction.Cat.Type` (případně **"Neznámý typ"**).

### 3) Spojnicový graf: Zůstatek v čase
- **Co zobrazuje:** vývoj **kumulativního zůstatku** v čase.
- **Jak se počítá:** zůstatek se průběžně přičítá/odečítá z transakcí: **Příjem = +částka**, **Výdaj = −částka**.
- **Osa X:** datum transakce (agregováno po dnech).

### 4) Skládaný sloupcový graf: Příjmy vs. výdaje po měsících
- **Co zobrazuje:** měsíční součty **příjmů** a **výdajů** ve formě skládaných sloupců.
- **Agregace:** seskupení podle **měsíce/roku** (label ve formátu `MM/YYYY`).

### 5) Sloupcový graf: Příjmy a výdaje podle členů
- **Co zobrazuje:** součty **příjmů** a **výdajů** pro každého člena rodiny.
- **Zdroje dat:** jméno člena z `Transaction.Member.Name` (případně **"Neznámý"**).

### 6) Spojnicový graf: Predikce vývoje zůstatku
- **Co zobrazuje:** odhad budoucího vývoje zůstatku v čase (series **"Predikce"**).
- **Horizont:** volitelně **Týden / Měsíc / Čtvrtletí / Rok** (7 / 30 / 90 / 365 dní).
- **Jak se počítá:** z historie se spočítá **průměrná denní změna** (defaultně z posledních 90 dní, pokud data existují) a ta se lineárně promítne do budoucna.
- **Vizualizace:**
  - segmenty čáry jsou barevně odlišeny podle směru (růst / pokles / beze změny),
  - je vykreslena nulová reference (0 Kč),
  - jsou doplněny svislé značky pro začátek a konec horizontu.

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

## Technologie

- C# / .NET (Windows Forms)
- Windows Forms
- LiteDB – embedded databáze
- LiveChartsCore.SkiaSharpView
  
---

## Autor

Lukáš Sandtner – školní projekt, 2026/2027
