# Trabajo 3 - Minijuego de Fútbol: Tiro al Arco

Este proyecto es un minijuego desarrollado en Unity como parte del curso de **Desarrollo de Videojuegos**, con el objetivo de simular tiros al arco en un entorno 3D.

---

## ✅ Avances logrados

### ⚽ Escenario, portería y balón
- Cancha de fútbol modelada en 3D con texturas aplicadas.
- Portería con capacidad de movimiento horizontal (eje Z) mediante script.
- Balón modelado en 3D, posicionado en el centro del escenario.

### 🎥 Cámara y control de dirección
- La cámara sigue a la pelota desde atrás y ligeramente elevada.
- Antes de disparar, el jugador puede mover la cámara horizontalmente con el mouse para apuntar.
- Al iniciar el juego, la cámara se posiciona automáticamente mirando hacia el arco.

---

## 🧩 Menú interactivo (UI)

Se implementó un menú principal y una pantalla de opciones utilizando el sistema de **UI de Unity**, accesibles al iniciar el juego.

### 🎮 Menú Principal
- Campo para ingresar el nombre del jugador (`InputField`).
- Botón para iniciar el juego.
- Botón para abrir el menú de opciones.

### ⚙️ Pantalla de Opciones
- Texto explicativo sobre la usabilidad y objetivo del juego.
- `Toggle` para activar la dificultad:
  - **Desactivado** (por defecto): la portería permanece estática.
  - **Activado**: la portería se mueve de un lado a otro, aumentando la dificultad.
- `Slider` para controlar el volumen de la música ambiental del menú.
- Botón para volver al menú principal.

---

## 🔊 Música ambiental
- Se agregó una pista de música de fondo en el menú.
- El `Slider` permite ajustar el volumen desde el 0% hasta el 100%.
- Al iniciar el menú, el volumen comienza en **10%** por defecto para evitar un sonido abrupto.

---

## 🧠 Dificultad y movimiento del arco
- El `Toggle` en el menú controla la variable `modoDificil`.
- Esta variable es utilizada en la escena de juego para determinar si el arco debe moverse.
- En modo difícil (`Toggle` activado), el arco se mueve automáticamente en el eje Z de forma oscilante usando `Mathf.Sin()`.

---

## 🥅 Detección de goles
- Se implementó la detección de goles utilizando un **panel invisible con Collider y Trigger** ubicado dentro de la portería.
- Al entrar la pelota (con tag `Pelota`) al área de gol, se imprime un mensaje de confirmación en la consola (`Debug.Log("¡GOL!")`).
- Todo el sistema de detección de gol está gestionado desde un script exclusivo (`DetectorGol.cs`).

---

## 👨‍💻 Desarrolladores

- Mauro  
- Jonnathan
