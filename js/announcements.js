document.addEventListener("DOMContentLoaded", () => {
  const searchInput = document.getElementById("announcement-search");
  const filterButtons = [...document.querySelectorAll(".filter-button")];
  const announcementCards = [...document.querySelectorAll(".announcement-card")];
  const resultCount = document.getElementById("announcement-result-count");
  const emptyState = document.getElementById("announcement-empty-state");

  if (!searchInput || filterButtons.length === 0 || announcementCards.length === 0 || !resultCount || !emptyState) {
    return;
  }

  let selectedCategory = "all";

  const updateAnnouncements = () => {
    const searchTerm = searchInput.value.trim().toLocaleLowerCase("tr-TR");
    let visibleCount = 0;

    announcementCards.forEach(card => {
      const matchesCategory = selectedCategory === "all" || card.dataset.category === selectedCategory;
      const matchesSearch = card.textContent.toLocaleLowerCase("tr-TR").includes(searchTerm);
      card.hidden = !matchesCategory || !matchesSearch;
      if (!card.hidden) visibleCount += 1;
    });

    resultCount.textContent = `${visibleCount} duyuru gösteriliyor`;
    emptyState.hidden = visibleCount > 0;
  };

  searchInput.addEventListener("input", updateAnnouncements);
  filterButtons.forEach(button => {
    button.addEventListener("click", () => {
      selectedCategory = button.dataset.filter;
      filterButtons.forEach(filterButton => {
        const isSelected = filterButton === button;
        filterButton.classList.toggle("is-active", isSelected);
        filterButton.setAttribute("aria-pressed", String(isSelected));
      });
      updateAnnouncements();
    });
  });

  updateAnnouncements();
});
