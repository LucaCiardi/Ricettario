document.addEventListener('DOMContentLoaded', function () {
    // Category filter functionality
    const categoryFilter = document.getElementById('categoryFilter');
    if (categoryFilter) {
        const recipeRows = document.querySelectorAll('.ricetta-row');

        categoryFilter.addEventListener('change', function () {
            const selectedCategory = this.value;

            recipeRows.forEach(row => {
                const categoria = row.querySelector('.categoria').textContent;
                if (!selectedCategory || categoria === selectedCategory) {
                    row.style.display = '';
                } else {
                    row.style.display = 'none';
                }
            });
        });
    }

    // Edit functionality
    const editButtons = document.querySelectorAll('.edit-btn');

    function createSelect(options, currentValue) {
        const select = document.createElement('select');
        select.className = 'form-control';

        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.textContent = `Seleziona ${currentValue}`;
        select.appendChild(defaultOption);

        options.forEach(option => {
            const opt = document.createElement('option');
            opt.value = option;
            opt.textContent = option;
            if (option === currentValue) {
                opt.selected = true;
            }
            select.appendChild(opt);
        });

        return select;
    }

    function createSaveButton() {
        const saveButton = document.createElement('button');
        saveButton.textContent = 'Salva';
        saveButton.className = 'btn btn-primary mt-2';
        return saveButton;
    }

    editButtons.forEach(button => {
        button.addEventListener('click', function () {
            const field = this.getAttribute('data-field');
            const id = this.getAttribute('data-id');
            const detailRow = this.closest('.detail-row');
            let currentValue = '';

            if (field === 'Ingredienti' || field === 'Istruzioni') {
                currentValue = detailRow.querySelector('pre')?.textContent || '';
                const textarea = document.createElement('textarea');
                textarea.className = 'form-control';
                textarea.rows = 10;
                textarea.value = currentValue;
                textarea.placeholder = `Inserisci ${field.toLowerCase()} su una nuova riga`;
                detailRow.querySelector('pre').replaceWith(textarea);
                textarea.focus();

                const saveButton = createSaveButton();
                textarea.after(saveButton);

                saveButton.addEventListener('click', function () {
                    if (textarea.value !== currentValue) {
                        updateField(id, field, textarea.value, detailRow);
                    }
                });
                return;
            }

            switch (field) {
                case 'Nome':
                case 'TipoCucina':
                    currentValue = detailRow.querySelector('p').textContent.trim();
                    const input = document.createElement('input');
                    input.type = 'text';
                    input.className = 'form-control';
                    input.value = currentValue;
                    input.placeholder = field === 'Nome' ? 'Nome della ricetta' : 'Tipo di cucina';
                    detailRow.querySelector('p').replaceWith(input);
                    input.focus();

                    const saveInputButton = createSaveButton();
                    input.after(saveInputButton);

                    saveInputButton.addEventListener('click', function () {
                        if (input.value !== currentValue) {
                            updateField(id, field, input.value, detailRow);
                        }
                    });
                    break;

                case 'TempoPreparazione':
                    currentValue = detailRow.querySelector('p').textContent.split(' ')[0];
                    const numberInput = document.createElement('input');
                    numberInput.type = 'number';
                    numberInput.className = 'form-control';
                    numberInput.min = '1';
                    numberInput.max = '480';
                    numberInput.value = currentValue;
                    detailRow.querySelector('p').replaceWith(numberInput);
                    numberInput.focus();

                    const saveNumberButton = createSaveButton();
                    numberInput.after(saveNumberButton);

                    saveNumberButton.addEventListener('click', function () {
                        const num = parseInt(numberInput.value);
                        if (num >= 1 && num <= 480) {
                            updateField(id, field, num.toString(), detailRow);
                        } else {
                            alert('Il tempo deve essere tra 1 e 480 minuti');
                        }
                    });
                    break;

                case 'Categoria':
                    currentValue = detailRow.querySelector('p').textContent.trim();
                    const categorieSelect = createSelect(
                        ['Antipasto', 'Primo', 'Secondo', 'Contorno', 'Dessert'],
                        currentValue
                    );
                    detailRow.querySelector('p').replaceWith(categorieSelect);
                    categorieSelect.focus();

                    categorieSelect.addEventListener('change', function () {
                        if (this.value) {
                            updateField(id, field, this.value, detailRow);
                        }
                    });
                    break;

                case 'Difficolta':
                    currentValue = detailRow.querySelector('p').textContent.trim();
                    const difficoltaSelect = createSelect(
                        ['Facile', 'Media', 'Difficile'],
                        currentValue
                    );
                    detailRow.querySelector('p').replaceWith(difficoltaSelect);
                    difficoltaSelect.focus();

                    difficoltaSelect.addEventListener('change', function () {
                        if (this.value) {
                            updateField(id, field, this.value, detailRow);
                        }
                    });
                    break;
            }
        });
    });

    function updateField(id, field, value, detailRow) {
        const token = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
        if (!token) {
            console.error('Token CSRF non trovato');
            return;
        }

        const formData = new FormData();
        formData.append('id', id);
        formData.append('field', field);
        formData.append('value', value);

        fetch('/Ricetta/ModificaCampo', {
            method: 'POST',
            body: formData,
            headers: {
                'RequestVerificationToken': token
            }
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
