<script>
    import { createEventDispatcher } from 'svelte';
    import { articleTypes, addArticle } from '../stores/articles.js';

    //Article Form values for creating new article.
    let title = '';
    let description = '';
    let articleDate = '';
    let articleTypeID = '';

    //Error message in case input values are not valid.
    let errorMessage = '';

    //Active tab variable from App.svelte.
    export let activeTab;

    //Watch for changes to the activeTab prop.
    $: {
        handleTabChange(activeTab);
    }

    //Reset values when switching tabs.
    const handleTabChange = (tab) => {
        if (tab == 'form') {
            errorMessage = '';
            title = '';
            description = '';
            articleDate = '';
            articleTypeID = '';
            maxDate = getTodayDate();
        }
    };

    //Dispatcher to indicate that new article has been created.
    const dispatch = createEventDispatcher();

    //Create new article and switch to article list tab.
    const handleSubmit = async () => {
        if (!title.trim() || !description.trim() || !articleDate || !articleTypeID) {
            errorMessage = 'All fields are required.';
            return;
        }

        await addArticle({ title, description, articleTypeID: parseInt(articleTypeID), articleDate });

        dispatch('submit');
    };

    //Get current date for date field constraint.
    const getTodayDate = () => {
        const today = new Date();
        const year = today.getFullYear();
        let month = today.getMonth() + 1;
        let day = today.getDate();

        // Add leading zero if month or day is a single digit
        month = month < 10 ? '0' + month : month;
        day = day < 10 ? '0' + day : day;

        return `${year}-${month}-${day}`;
    };

    //Set maximum date for new articles as current date.
    let maxDate = getTodayDate();
</script>

<form on:submit|preventDefault={handleSubmit}>
    <div class="form-group">
        <label for="title">Title</label>
        <input type="text" id="title" placeholder="Title" bind:value={title} required maxlength="50"/>
        <small class="hint">Maximum 50 characters</small>
    </div>
    <div class="form-group">
        <label for="description">Description</label>
        <textarea id="description" placeholder="Description" bind:value={description} required></textarea>
    </div>
    <div class="form-group">
        <label for="articleDate">Article Date</label>
        <input type="date" id="articleDate" bind:value={articleDate} required max={maxDate}/>
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
    {#if errorMessage}
        <p class="error-message">{errorMessage}</p>
    {/if}
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

    .error-message {
        color: red;
        margin-top: 0.5rem;
        font-size: 0.875rem;
    }
</style>