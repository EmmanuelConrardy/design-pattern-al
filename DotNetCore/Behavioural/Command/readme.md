# Command
Ce patron embo&icirc;te une demande dans un objet, permettant de param&eacute;trer, mettre en file d'attente, journaliser et annuler des demandes. 
Dans ce patron un objet command correspond &agrave; une op&eacute;ration &agrave; effectuer. 
L'interface de cet objet comporte une m&eacute;thode "execute". 
Pour chaque op&eacute;ration, l'application va cr&eacute;er un objet diff&eacute;rent qui impl&eacute;mente cette interface - qui comporte une m&eacute;thode execute.
L'op&eacute;ration est lanc&eacute;e lorsque la m&eacute;thode execute est utilis&eacute;e. 

## Exemple d'utilisation
Le pattern commande des actions ou des requ&ecirc;tes des boutton d'une interface graphique

## Images / analogie
Les boutton d'une manette ou les buttons plus, moins, diviser, multiplier d'une calculatrice sont des "commandes".

On imagine facilement que &agrave; chaque fois que l'on appuiera sur un boutton une action sera execut&eacute;e.

## Liens

https://refactoring.guru/design-patterns/command
