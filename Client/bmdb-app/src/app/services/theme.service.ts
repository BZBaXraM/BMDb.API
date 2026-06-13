import { effect, Injectable, signal } from '@angular/core';

type Theme = 'light' | 'dark';

@Injectable({
	providedIn: 'root',
})
export class ThemeService {
	readonly theme = signal<Theme>(this.resolveInitial());

	constructor() {
		effect(() => {
			const theme = this.theme();
			document.documentElement.classList.toggle('dark', theme === 'dark');
			localStorage.setItem('theme', theme);
		});
	}

	toggle() {
		this.theme.update((t) => (t === 'dark' ? 'light' : 'dark'));
	}

	private resolveInitial(): Theme {
		const saved = localStorage.getItem('theme');
		if (saved === 'light' || saved === 'dark') {
			return saved;
		}
		return window.matchMedia('(prefers-color-scheme: dark)').matches
			? 'dark'
			: 'light';
	}
}
