document.addEventListener('DOMContentLoaded', function () {
    // Enhanced validation for TempoPreparazione
    const tempoInput = document.getElementById('TempoPreparazione');
    if (tempoInput) {
        tempoInput.addEventListener('input', function (e) {
            this.value = this.value.replace(/[^0-9]/g, '');

            if (this.value) {
                const value = parseInt(this.value);
                if (value < 1) this.value = '1';
                if (value > 480) this.value = '480';
            }
        });
    }

    // Enhanced form validation with client-side validation
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function (e) {
            if (!validateForm()) {
                e.preventDefault();
            }
        });
    }
});

function validateForm() {
    const ingredienti = document.getElementById('Ingredienti').value.trim();
    const istruzioni = document.getElementById('Istruzioni').value.trim();
    const nome = document.getElementById('Nome').value.trim();
    const categoria = document.getElementById('Categoria').value.trim();

    let isValid = true;
    const errors = [];

    if (!nome) {
        errors.push('Il nome è obbligatorio');
        isValid = false;
    }

    if (!categoria) {
        errors.push('La categoria è obbligatoria');
        isValid = false;
    }

    if (!ingredienti) {
        errors.push('Gli ingredienti sono obbligatori');
        isValid = false;
    }

    if (!istruzioni) {
        errors.push('Le istruzioni sono obbligatorie');
        isValid = false;
    }

    if (!isValid) {
        alert(errors.join('\n'));
    }

    return isValid;
}
