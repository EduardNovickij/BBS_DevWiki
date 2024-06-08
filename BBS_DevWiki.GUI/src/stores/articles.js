import { writable } from 'svelte/store';

const API_URL = "https://localhost:44390/api/";
export const articles = writable([]);
export const articleTypes = writable([]);

//Fetch all articles using api
export const fetchArticles = async () => {
    const response = await fetch(API_URL + 'Article');
    const data = await response.json();
    articles.set(data);
};

//Fetch all article types using api
export const fetchArticleTypes = async () => {
    const response = await fetch(API_URL + 'ArticleType');
    const data = await response.json();
    articleTypes.set(data);
};

//Add new article from provided data using api
export const addArticle = async (article) => {
    const response = await fetch(API_URL + 'Article', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(article),
    });
    const data = await response.json();
    articles.update((current) => [...current, data]);
};

//Delete existing article by id using api
export const deleteArticle = async (id) => {
    await fetch(API_URL + `Article/${id}`, {
        method: 'DELETE',
    });
    articles.update((current) => current.filter(article => article.id !== id));
};