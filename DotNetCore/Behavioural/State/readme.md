# State - Behaviour

Ce patron permet &agrave; un objet de modifier son comportement lorsque son &eacute;tat interne change. 
Ce patron est souvent utilis&eacute; pour impl&eacute;menter une machine &agrave; &eacute;tats ou un workflow. 
Un exemple d'appareil &agrave; &eacute;tats est le lecteur audio - dont les &eacute;tats sont lecture, enregistrement, pause et arrêt. 
Selon ce patron il existe une classe machine &agrave; &eacute;tats, et une classe pour chaque &eacute;tat. 
Lorsqu'un &eacute;v&eacute;nement provoque le changement d'&eacute;tat, la classe machine &agrave; &eacute;tats se relie &agrave; un autre &eacute;tat 
et modifie ainsi son comportement.

## Exemple d'utilisation

Quand la classe doit g&eacute;rer des &eacute;tats.

## Images / analogie

Lecteur vid&eacute;o avec les &eacute;tats lecture, pause, rembobinage 

## Liens

https://refactoring.guru/design-patterns/state
