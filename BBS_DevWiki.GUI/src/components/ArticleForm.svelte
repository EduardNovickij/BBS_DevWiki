<script>
    import { createEventDispatcher } from 'svelte';
    import { articleTypes, addArticle } from '../stores/articles.js';
    let title = '';
    let description = '';
    let articleDate = '';
    let articleTypeID = '';

    //Event dispatcher to indicate that a new article has been created.
    const dispatch = createEventDispatcher();

    //Create new article and reset input parameters.
    const handleSubmit = async () => {
        await addArticle({ title, description, articleTypeID: parseInt(articleTypeID), articleDate });
        title = '';
        description = '';
        articleDate = '';
        articleTypeID = '';

        //Dispatch 'submit' event so event listener in App.svelte switches to ArticleList tab.
        dispatch('submit');
    };
</script>

<form on:submit|preventDefault={handleSubmit}>
    <div class="form-group">
        <label for="title">Title</label>
        <input type="text" id="title" placeholder="Title" bind:value={title} required />
    </div>
    <div class="form-group">
        <label for="description">Description</label>
        <textarea id="description" placeholder="Description" bind:value={description} required></textarea>
    </div>
    <div class="form-group">
        <label for="articleDate">Article Date</label>
        <input type="date" id="articleDate" bind:value={articleDate} required />
    </div>
    <div class="form-group">
        <label for="articleType">Article Type</label>
        <select id="articleType" bind:value={articleTypeID} required>
            <option value="" disabled>Select Type</option>
            {#each $articleTypes as type}
                <option value={type.ID}>{type.Name}</option>
            {/each}
        </select>
    </div>
    <button type="submit" class="submit-btn">Submit</button>
</form>

<style>
    form {
        display: flex;
        flex-direction: column;
        gap: 1rem;
        background-color: #f9f9f9;
        padding: 2rem;
        border-radius: 8px;
        box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
        max-width: 500px;
        margin: 0 auto;
    }

    .form-group {
        display: flex;
        flex-direction: column;
    }

    label {
        margin-bottom: 0.5rem;
        font-weight: bold;
        color: #333;
    }

    input, textarea, select {
        padding: 0.5rem;
        border: 1px solid #ddd;
        border-radius: 4px;
        font-size: 1rem;
        background-color: #fff;
    }

    textarea {
        resize: vertical;
    }

    input:focus, textarea:focus, select:focus {
        border-color: #007bff;
        outline: none;
        box-shadow: 0 0 4px rgba(0, 123, 255, 0.25);
    }

    .submit-btn {
        padding: 0.75rem;
        background-color: #007bff;
        color: #fff;
        border: none;
        border-radius: 4px;
        font-size: 1rem;
        cursor: pointer;
        transition: background-color 0.3s ease;
    }

    .submit-btn:hover {
        background-color: #0056b3;
    }
</style>