# MarsRover

Questo progetto risolve il problema MarsRover

Il Rover si muove all'interno di una superficie (Plateau). Per comodità la superficie è rappresentata da una griglia.
Il Rover ha un posizione iniziale definita dalle coordinate X e Y e da una direzione (punti cardinali).
Un esempio di posizione del Rover è 0,0,N: in questo caso il Rover è posizionato nell'angolo inferiore sinistro con direzione Nord.

Il Rover è in grado di interpretare 4 comandi:
 1. L (Left/Sinistra)
 2. R (Right/Destra)
 3. F (Forward/Avanti)
 4. B (Backward/Indietro)
I comandi L e R ruotano il Rover di 90° rispettivamente a sinistra e destra senza alterare la posizione.
I comandi F e B non alternano la direzione ma la posizione.
Per esempio se il Rover è in direzione N nel punto (x,y) uno spostamento in avanti (F) lo sposterà nel punto (x,y+1).

# Input
Il Plateau è inizializzato con la definizione della dimensione.
Il Rover è inizializzato specificando il Plateau, la posizione e la direzione. Se la posizione iniziale non è valida perché fuori dall'intervallo consentito o perché occupata da un ostacolo il sistema genera un'eccezione.

Lo spostamento del Rover è effettuato con l'esecuzione del metodo **RunCommands**. Questo metodo riceve in input una stringa di comandi.
Ciascun comando ricevuto è validato e successivamente interpretato.
Il processo di validazione valuta la presenza nella posizione di destinazione di un ostacolo generando un'eccezione specifica.

## Comando L
Il comando L (Left) corrisponde alla rotazione in senso antiorario di 90°. Nel caso specifico essendo la direzione rappresentata dai 4 punti cardinali la regola del cambio di posizione è la seguente:
N-->W
W-->S
S-->E
E-->N

## Comando R
Il comando R (Right) corrisponde alla rotazione in senso orario di 90°. Nel caso specifico essendo la direzione rappresentata dai 4 punti cardinali la regola del cambio di posizione è la seguente:
N-->E
E-->S
S-->W
E-->N

## Comando F
Il comando F (Forward) corrisponde al movimento in avanti rispetto alla direzione del Rover. Lo spostamento in base alla direzione del Rover modifica la coordinata X o Y. Il sistema considera la sfericità del pianeta.

## Comando B
Il comando B (Backward) corrisponde al movimento all'indietro rispetto alla direzione del Rover. Lo spostamento in base alla direzione del Rover modifica la coordinata X o Y. Il sistema considera la sfericità del pianeta.

# Output
Il sistema dato un input restituisce la nuova posizione del Rover (coordinate e direzione). Nel caso di anomalie il sistema genera eccezioni custom.

