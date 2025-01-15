document.addEventListener('DOMContentLoaded', function () {
    // Validation for TempoPreparazione
    const tempoInput = document.getElementById('TempoPreparazione');
    if (tempoInput) {
        tempoInput.addEventListener('input', function (e) {
            // Remove non-numeric characters
            this.value = this.value.replace(/[^0-9]/g, '');

            // Ensure value is between 1 and 480
            if (this.value) {
                const value = parseInt(this.value);
                if (value < 1) this.value = '1';
                if (value > 480) this.value = '480';
            }
        });
    }

    // Form validation
    const form = document.querySelector('form');
    if (form) {
        form.addEventListener('submit', function (e) {
            const ingredienti = document.getElementById('Ingredienti').value.trim();
            const istruzioni = document.getElementById('Istruzioni').value.trim();

            if (!ingredienti || !istruzioni) {
                e.preventDefault();
                alert('Ingredienti e istruzioni sono obbligatori');
            }
        });
    }
});
