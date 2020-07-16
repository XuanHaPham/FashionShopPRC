export function getByTitle (list, keyword) {
    const search = keyword.trim().toLowerCase();
    if (!search.length) return list;
    return list.filter(item => item.name.toLowerCase().indexOf(search) > -1);
}

export function getByCategory (list, Category) {
    const search = Category;
    if (search < 0) return list;
    return list.filter(item => item.categoryID === Category);
}