let gameState;

document.addEventListener('keydown', handleKeyPress);

function initializeGame(initialState) {
    gameState = initialState;
    drawMap(gameState);
}

function handleKeyPress(event) {
    let direction;
    switch (event.key) {
        case 'ArrowUp': direction = 'up'; break;
        case 'ArrowDown': direction = 'down'; break;
        case 'ArrowLeft': direction = 'left'; break;
        case 'ArrowRight': direction = 'right'; break;
        default: return; // Ignore other keys
    }

    fetch('/Index?handler=Move', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify({ direction })
    })
        .then(response => response.json())
        .then(newState => {
            gameState = newState;
            drawMap(gameState);
        });
}

function drawMap(state) {
    const board = document.getElementById('game-board');
    board.innerHTML = ''; // Clear existing map

    // Example: simple 20x20 grid, adjust as needed
    const gridSize = 20;
    for (let y = 0; y < gridSize; y++) {
        for (let x = 0; x < gridSize; x++) {
            const cell = document.createElement('div');
            cell.className = 'cell';
            if (state.PacmanPosition.X === x && state.PacmanPosition.Y === y) {
                cell.classList.add('pacman');
            } else if (state.WallPositions.some(p => p.X === x && p.Y === y)) {
                cell.classList.add('wall');
            } else if (state.CoinPositions.some(p => p.X === x && p.Y === y)) {
                cell.classList.add('coin');
            } else if (state.GhostPositions.some(p => p.X === x && p.Y === y)) {
                cell.classList.add('ghost');
            }
            board.appendChild(cell);
        }
    }
}
