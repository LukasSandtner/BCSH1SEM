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
└── Program.cs
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
