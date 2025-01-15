document.addEventListener('DOMContentLoaded', function () {
    const editButtons = document.querySelectorAll('.edit-btn');

    editButtons.forEach(button => {
        button.addEventListener('click', function () {
            const field = this.getAttribute('data-field');
            const id = this.getAttribute('data-id');
            const detailRow = this.closest('.detail-row');
            let currentValue = '';

            // Get current value based on field type
            if (field === 'Ingredienti' || field === 'Istruzioni') {
                currentValue = detailRow.querySelector('pre').textContent;
            } else {
                currentValue = detailRow.querySelector('p').textContent.split(':')[1].trim();
            }

            let newValue;
            switch (field) {
                case 'TempoPreparazione':
                    newValue = prompt(`Modifica ${field} (1-480 minuti):`, currentValue);
                    if (newValue !== null) {
                        const num = parseInt(newValue);
                        if (isNaN(num) || num < 1 || num > 480) {
                            alert('Il tempo deve essere tra 1 e 480 minuti');
                            return;
                        }
                    }
                    break;

                case 'Categoria':
                    newValue = prompt('Seleziona categoria (Antipasto/Primo/Secondo/Contorno/Dessert):', currentValue);
                    if (newValue !== null && !['Antipasto', 'Primo', 'Secondo', 'Contorno', 'Dessert'].includes(newValue)) {
                        alert('Categoria non valida');
                        return;
                    }
                    break;

                case 'Difficolta':
                    newValue = prompt('Seleziona difficoltà (Facile/Media/Difficile):', currentValue);
                    if (newValue !== null && !['Facile', 'Media', 'Difficile'].includes(newValue)) {
                        alert('Difficoltà non valida');
                        return;
                    }
                    break;

                default:
                    newValue = prompt(`Modifica ${field}:`, currentValue);
            }

            if (newValue !== null && newValue !== currentValue) {
                const formData = new FormData();
                formData.append('id', id);
                formData.append('field', field);
                formData.append('value', newValue);

                fetch('/Ricetta/ModificaCampo', {
                    method: 'POST',
                    body: formData
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            window.location.reload();
                        } else {
                            alert('Errore durante la modifica: ' + (data.message || 'Errore sconosciuto'));
                        }
                    })
                    .catch(error => {
                        console.error('Error:', error);
                        alert('Errore durante la modifica');
                    });
            }
        });
    });
});
