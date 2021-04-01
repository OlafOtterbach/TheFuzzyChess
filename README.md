# The Fuzzy Chess

Olaf Otterbach, 14.03.2021 - 30.03.2021

Demonstration eines über Fuzzy-Logik regelgesteuerten Schachspieles gegen sich selber.
Bei jedem Durchgang werden alle Züge einer Seite mit Fuzzy-Logik-Regeln bewertet und
der beste Zug wird für eine Seite ausgeführt. Dann kommt die Gegenseite zum Zuge.
Dies ist analog dem MinMax-Algorithmus. Allerdings nur ein- bis zwei Züge vorrausschauend.

Die Regeln sind über das sogenannte Specification Pattern definiert, wie man es auch auf Wikipedia findet. 
Anstatt normaler boolscher Logik ist das Pattern aber auf Fuzzy-Logik erweitert worden.
Die Regeln werden evaluiert und der Fuzzy-Wert zwischen 0.0 und 1.0 mit einem Evaluationswert der Regel multipliziert. 
Die Summe aller Evaluationswerte ergibt den Wert eines Schachzuges. Der Schachzug mit dem höchsten Wert wird ausgeführt.

Da die Regeln bei weitem noch nicht die Fähigkeiten eines schlechten Schachspielers abdecken, 
erhält man noch einen sehr chaotische Spielablauf.
Am Verhalten einer Figur kann aber die Wirksamkeit einzelner Regeln beobachtet werden.

Zum Bespiel bewirken die Regeln

     „Zielfeld ist leer“ UND „Zielfeld ist bedroht“ UND NICHT(„Zielfeld ist gedeckt“) => -1000 Punkte,

und

     „Zielfeld ist leer“ UND „Zielfeld ist bedroht“ UND „Zielfeld ist gedeckt“ UND "Bedrohender Gegner ist niedriger" => -1000 Punkte,

dass eine Figur ein bedrohtes Feld meidet, wenn möglich.

Für ein einigermaßen intelligentes Spiel müssten freilich noch viele Regeln und auch verfeinerte Betrachtungen 
eines Spielzuges eingefügt werden.


 
