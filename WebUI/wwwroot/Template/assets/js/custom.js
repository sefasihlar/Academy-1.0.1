// Tüm checkboxları seçin
const checkboxes = document.querySelectorAll('input[type="checkbox"]');

// Her bir checkbox üzerinde işlem yapın
checkboxes.forEach(function(checkbox) {
  // Checkbox durumunu izleyin
  checkbox.addEventListener('change', function() {
    // Ebeveyn div'i bulun
    const parentDiv = checkbox.parentNode;
    // Checkbox işaretli ise, arkaplan rengini yeşile ayarlayın
    if (checkbox.checked) {
      parentDiv.style.backgroundColor = 'green';
    } else {
      parentDiv.style.backgroundColor = '';
    }
  });
});