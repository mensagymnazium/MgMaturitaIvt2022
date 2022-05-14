# Mensa gymnázium, o.p.s. - Maturitní zkouška z IVT - Zadání

## Pokyny
Níže najdete zadání čtyř úloh. Tři z nich naprogramujte ve vhodném programovacím jazyce, jednu můžete vynechat, nebo využít pro získání bonusových bodů. Na práci máte 240 minut, po krátké přestávce pak 15 minut na obhajobu před komisí.

Komunikovat smíte pouze se zkoušejícím(i), ale jinak můžete používat internet, literaturu, knihovny, tutoriály, dokumentace, svoje vlastní poznámky, svůj vlastní kód apod.

Pište přehledný, komentovaný, čitelný kód. Nebojte se ptát zkoušejících, v nejhorším vám neodpovíme, nebo nabídneme popostrčení kupředu za cenu bodové ztráty.

### Odevzdání a obhajoba
Založte si privátní GitHub repozitář(e), do kterého **průběžně pushujte** postup své práce. Do repozitáře [**nastavte přístup (colaborator)**](https://docs.github.com/en/account-and-profile/setting-up-and-managing-your-github-user-account/managing-access-to-your-personal-repositories/inviting-collaborators-to-a-personal-repository) pro následující GitHub účty:
* `hakenr`

Při závěrečné obhajobě (15 min) bude vaším úkolem představit řešení a funkčnost jednotlivých úloh:
* vysvětlit stručně postup algoritmu,
* ukázat a popsat zdrojový kód (lze spojit s vysvětlováním algoritmu),
* předvést spustitelný a funkční program (musí být možné předat vstupy a ověřit výstupy)

Pamatujte na omezený čas obhajoby, na každou úlohu je max. 5 minut.

### Hodnocení
Za každou úlohu můžete získat 0-30 bodů, dalších 0-10 bodů pak můžete získat u obhajoby.
Výsledné hodnocení se určí takto:
* 86 a více bodů - výborné,
* 68 až 85 bodů - chvalitebné,
* 50 až 67 bodů - dobré,
* 33 až 49 bodů - dostatečné,
* 32 a méně bodů - nedostatečné - neuspěl(a)

## Úloha 1: Pohyb koně po šachovnici
Mějme šachovnici s M sloupci a N řádky, počáteční pozici A a koncovou pozici B. Napište program, který určí nejmenší možný počet tahů koněm pro přesun z A do B.

### Vstupy:
* rozměry šachovnice M a N (dvě čísla)
* souřadnice A (dvě čísla)
* souřadnice B (dvě čísla)

### Výstup
* nejmenší možný počet tahů pro přesun koně na šachovnici MxN z pole A do pole B

### Příklady:
#### Příklad 1
```
Vstup:
8 8
4 4
4 2
Výstup:
2
```
#### Příklad 2
```
Vstup:
3 3
1 1
2 1
Výstup:
3
```
#### Příklad 3
```
Vstup:
3 6
2 1
1 6
Výstup:
4
```

